// параметры отрисовки графика
var params = {
    ky: 1000, // коэф Масштабирования шкалы по у
    kx: 50, // коэф Масштабирования шкалы по x , количество пикселей на %

    oyn: 20, // начальный отступ 0 графика по y
    oxn: 50, //начальный отступ 0 графика по х

    ly: 1900, // длина оси у
    lx: 1900, // длина оси х

    stepX: 5, //шаг сетки по x в %
    stepY: 0.1 //шаг сетки по y в ped
};

// параметры объекта
var item = {
    pricePerItem  : 0.03,
    purchasePrice : 102.5,
    markup        : 2,
    beginQuantity : 500,
    quantity      : 1000,
    stepQuantity  : 1,
    ky: 1000, // коэф Масштабирования шкалы по у
    kx: 50, // коэф Масштабирования шкалы по x , количество пикселей на %
    selectedPoint : null
};

// расчитанная таблица
/*
       quantity , sellingPrice ,profit,tax,markup
 */
   var table  = [];

function populateChartAndTable() {
       item.purchasePrice = Number($("#SelectedItem_PurchasePrice").val());
       item.pricePerItem = Number($("#SelectedItem_Price").val());
       item.markup = Number($("#SelectedItem_Markup").val());
       item.beginQuantity = Number($("#SelectedItem_BeginQuantity").val());
       item.stepQuantity = Number($("#SelectedItem_Step").val());


    
    calcTable();
    printTable();
    redrawChart();
    scrollToFirstPoint();

 //обработка клика по точке

document.getElementById('graph').addEventListener("click",function(event){
    clickPoint(event);
});


        //обработка клика по таблице
document.getElementById('tbody').addEventListener("click",function(event){
    clickRow(event);
    
});

//масштабирование колесиком мыши
  addOnWheel(graph, function(e) {
      var delta = e.deltaY || e.detail || e.wheelDelta;
	  var graphContainer = $('.graph-container');
	 var scrollX =  graphContainer.scrollLeft();
         var scrollY =  graphContainer.scrollTop();
	  
      // отмасштабируем при помощи CSS
      if (delta > 0){
           item.kx += 5  ;
           item.ky += 5  ;
        $(graphContainer).scrollLeft(scrollX + 5 * params.stepX ); 
        $(graphContainer).scrollTop(scrollY + 5 * params.stepY );
      }
      else
         if (item.kx > 5 && item.ky > 5){
             item.kx -= 5  ;
             item.ky -= 5  ;
             
        $(graphContainer).scrollLeft(scrollX - 5 * params.stepX ); 
        $(graphContainer).scrollTop(scrollY - 5 * params.stepY );
			
         };
     redrawChart();
    // отменим прокрутку 
    e.preventDefault();
    });

};



// отрисовка осей
function drawAxis(){

    var xAxis  = $(document.createElement('div')).addClass('horizontal-axis') ;
    var yAxis = $(document.createElement('div')).addClass('vertical-axis') ;
    $(xAxis).css({"width":params.lx, "left": params.oxn, "top": params.oyn + params.ly });
    $(yAxis).css({"height":params.ly, "left": params.oxn , "top": params.oyn});
    $('#graph').append(xAxis, yAxis);

}


// отрисовка сетки
function drawGrid(){
  lineStepX = params.stepX * item.kx;
  lineStepY = params.stepY * item.ky;

    // vertical lines
    xSlug = 0;
  for (var vLine = 100 ; vLine < params.lx ; vLine += lineStepX){
      var x = params.oxn + vLine ;

      //x lines
      var lineV  = $(document.createElement('div')).addClass('vertical-line') ;
      $(lineV).css({"height":params.ly, "left":  x, "top": params.oyn });
      $('#graph').append(lineV);

      // slug on x axis
      var divX  = $(document.createElement('div')).text(100 + xSlug).addClass('slug-x') ;
      $(divX).css({"left":  x - 10, "top": params.oyn + params.ly });
      $('#graph').append(divX);
      xSlug += params.stepX;

  }
  // horizontal lines
  var beginY = params.oyn + params.ly;
  ySlug = 0;
  for (var hLine = 1 ; (beginY - hLine * lineStepY )> params.oyn ; hLine++){
      var y = beginY - hLine * lineStepY ;
      ySlug += params.stepY;

      var lineH  = $(document.createElement('div')).addClass('horizontal-line') ;
      $(lineH).css({"width":params.lx, "top":  y, "left": params.oxn });
      $('#graph').append(lineH);

      // slug on y axis
      var divY  = $(document.createElement('div')).text(ySlug.toFixed(2)).addClass('slug-y') ;
      $(divY).css({ "top":  y - 10, "left": params.oxn - 30  });
      $('#graph').append(divY);

  }

}


function calcTable (){
    var j = 0;
    for (var i = item.beginQuantity; i <= item.quantity; i +=item.stepQuantity){

        sellingPrice = (i * item.pricePerItem + item.markup).toFixed(0);
        markup =   sellingPrice - (item.pricePerItem * i) ;
        tax = 0.5 + markup * 99.5/(1990 + markup);
        profit = sellingPrice - (item.pricePerItem * item.purchasePrice * i / 100) - tax;
        table[j] = [i, sellingPrice, profit.toFixed(2), tax.toFixed(2),
            (sellingPrice /(i * item.pricePerItem ) * 100).toFixed(2)];
         j++;
    }
}

function printTable(){
    var j = 0;
    var rows = '';
    var classRow ='';
     $('#tbody').empty();
    for (var i = item.beginQuantity; i <= item.quantity; i +=item.stepQuantity){

     
      rows += '<tr  id = "row-' + j +'">\n' +
                 '<td class="col-xs-2 text-center">' + table[j][0] + '</td>\n' +
                 '<td class="col-xs-3 text-center">' + table[j][1] + '</td>\n' +
                 '<td class="col-xs-3 text-center">' + table[j][2] + '</td>\n' +
                 '<td class="col-xs-2 text-center">' + table[j][3] + '</td>\n' +
                 '<td class="col-xs-2 text-center">' + table[j][4] + '</td>\n' +

               '</tr>\n';
         j++;
    }
    $('#tbody').append(rows);
}


function drawChart(){
    lengthTable = table.length;

    var point = '';

    for (i = 0; i < lengthTable; i++){

        x = 100 + params.oxn +  (table[i][4] - 100)  * item.kx;
        if ( x > params.oxn + params.lx) continue;
        y = params.oyn + params.ly - table[i][2] * item.ky;
        if ( y >params.oyn + params.ly) continue;
         (i == item.selectedPoint)? classPoint = 'point-selected': classPoint = 'point';
        point += '<div class="' + classPoint + '"' +
                'id = "point-' + i + '"'+
                'title = "profit ' + table[i][2]+ ', markup ' + table[i][4] + ', '+
                'quatity '  + table[i][0]+'" '+
                'style="left:' + x + 'px; top:'+ y +'px;"></div>'+
                '\n';

    }
    $('#graph').append(point);

}

function redrawChart(){
    $('#graph').empty();
    drawAxis();
    drawGrid();
    drawChart();
}



// обработка клика на точке
function clickPoint(event){
    if (event.target.className === 'point'){
      var oldPoint =  item.selectedPoint;
      item.selectedPoint = event.target.id.substr(6);
	  
	  if (oldPoint !==null){
		var oldSelectedPoint = document.getElementById('point-' + oldPoint);
		if (oldSelectedPoint !== null){
				oldSelectedPoint.className = "point" ;
				}
		
		 document.getElementById('row-' + oldPoint).className = ""; 
	   }
      document.getElementById('point-' + item.selectedPoint).className = "point-selected";
      
      var selectedRow = document.getElementById('row-' + item.selectedPoint); 
      if (selectedRow !== null){
        selectedRow.className = "success";
        //scroll to selected row
       $('#tbody').animate({scrollTop: item.selectedPoint * 37},600);
    }
    
      
    }

}
// обработка клика по таблице
function clickRow(event){
    
     if (event.target.parentNode.tagName === 'TR'){
         var oldPoint =  item.selectedPoint;
         
         oldRow = document.getElementById('row-' + oldPoint);
         item.selectedPoint = event.target.parentNode.id.substr(4);
         selectedRow = document.getElementById('row-' + item.selectedPoint);
            
             if (   table[item.selectedPoint][2] < 0){
             selectedRow.className = "danger";
             redrawChart();
         }
            else {
                selectedRow.className = "success";
                redrawChart();
                scrollToSelectedPoint();
            }
            
         if (oldRow !== null ){
             oldRow.className = "";
         }
         
         
    }
}

//добавление слушателя к колесу мыши
function addOnWheel(elem, handler) {
      if (elem.addEventListener) {
        if ('onwheel' in document) {
          // IE9+, FF17+
          elem.addEventListener("wheel", handler);
        } else if ('onmousewheel' in document) {
          // устаревший вариант события
          elem.addEventListener("mousewheel", handler);
        } else {
          // 3.5 <= Firefox < 17, более старое событие DOMMouseScroll пропустим
          elem.addEventListener("MozMousePixelScroll", handler);
        }
      } else { // IE8-
        text.attachEvent("onmousewheel", handler);
      }
    }

// скролл к точке или вывод сообщения "out of range "
function scrollToFirstPoint(){
    lengthTable = table.length;
    graphContainer =  $('.graph-container');
    pointFound = false;
    var x, y;
    for ( i = 0; i < lengthTable; i++){
        if (table[i][2] >= 0 ){
            x = 100 + params.oxn +  (table[i][4] - 100)  * item.kx;
            if ( x > params.oxn + params.lx) continue;
            y = params.oyn + params.ly - table[i][2] * item.ky;
            if ( y >params.oyn + params.ly) continue;
            pointFound = true;
            break;
        }
       
    }
    
        if (pointFound === true){
           
            centerX = graphContainer.width();
            centerY = graphContainer.height();
            
            
        graphContainer.scrollLeft(x - centerX/2 ); 
        graphContainer.scrollTop(y - centerY/2 );
        }
        else {
            x =  graphContainer.scrollLeft() + 100;
            y =  graphContainer.scrollTop() + 100 ;
            
            $('#graph').append('<div class = "out-of-range"' +
                'style="left:' + x + 'px; top:'+ y  +'px;">'+
                'Out of range </div>');
        }
    
    
}
// scroll to selected point by row
function scrollToSelectedPoint(){
     var x, y;
    graphContainer =  $('.graph-container');
    
   
      x = 100 + params.oxn +  (table[item.selectedPoint][4] - 100)  * item.kx;
      y = params.oyn + params.ly - table[item.selectedPoint][2] * item.ky;
       // если точка в видимой области графика
        if (x <= params.oxn + params.lx && y <= params.oyn + params.ly   ){
           
            centerX = graphContainer.width();
            centerY = graphContainer.height();
            
        graphContainer.animate({scrollTop: y - centerY/2},800);
        graphContainer.scrollLeft(x - centerX/2 ); 
        
        }
        else {
            x =  graphContainer.scrollLeft() + 100;
            y =  graphContainer.scrollTop() + 100 ;
            
            $('#graph').append('<div class = "out-of-range"' +
                'style="left:' + x + 'px; top:'+ y  +'px;">'+
                'Out of range </div>');
        }
    
    
}

