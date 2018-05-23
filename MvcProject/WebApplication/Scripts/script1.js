////////////////////////////////////////
//　SCRIPT
////////////////////////////////////////
$(function(){
	var setElm = $('.slidePanel'),
	slideSpeed = 500;

	setElm.each(function(){
		var self = $(this),
		selfWidth = self.innerWidth(),
		selfUl = self.find('ul'),
		selfLi = selfUl.find('li'),
		listWidth = selfLi.outerWidth(),
		listCount = selfLi.length,
		slideWidth = listWidth*listCount,
		moveCount = Math.round(selfWidth/listWidth),
		wrapSplit = Math.ceil(listCount/moveCount);

		selfUl.css({width:slideWidth});

		if(selfWidth < slideWidth){
			self.append('<a href="javascript:void(0);" class="btnPrev"></a><a href="javascript:void(0);" class="btnNext"></a><div class="pagiNation"></div>').find('ul').wrapAll('<div class="slideWrap" />');

			var pagination = self.find('.pagiNation');

			$.each(new Array(wrapSplit),function(i){
				pagination.append('<a href="javascript:void(0);" class="pn'+(i+1)+'"></a>');
			});

			var pnPoint = pagination.find('a'),
			pnFirst = pagination.find('a:first'),
			pnLast = pagination.find('a:last'),
			pnCount = pagination.find('a').length;

			pnFirst.addClass('pnActive');

			pnPoint.click(function(){
				if(!(selfUl.is(':animated'))){
					var showCont = pnPoint.index(this);

					selfUl.animate({left: '-' + ((listWidth*moveCount)*showCont)},slideSpeed);

					pnPoint.removeClass('pnActive');
					$(this).addClass('pnActive');
				}
			});

			var btnNext = self.find('.btnNext'),
			btnPrev = self.find('.btnPrev');

			btnNext.click(function(){
				if(!(selfUl.is(':animated'))){
					var setActive = pagination.find('.pnActive'),
					pnIndex = pnPoint.index(setActive),
					pnNum = pnIndex+1;

					if(pnCount == pnNum){
						pnFirst.click();
					} else {
						setActive.next('a').click();
					}
				}
			});

			btnPrev.click(function(){
				if(!(selfUl.is(':animated'))){
					var setActive = pagination.find('.pnActive'),
					pnIndex = pnPoint.index(setActive),
					pnNum = pnIndex+1;

					if(1 == pnNum){
						pnLast.click();
					} else {
						setActive.prev('a').click();
					}
				}
			});
		}
	});
});
