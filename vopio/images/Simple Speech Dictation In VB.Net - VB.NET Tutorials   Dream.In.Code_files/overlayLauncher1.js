// JavaScript Document

// Text Message 
NS_WA_AdText = "Advertisement brought to you by " + NS_WA_SiteText; 

// set by NS_WA_launchWelcomeAd
var NS_WA_siteW, NS_WA_siteH;

// all the other stuff
var NS_WA_onResize = new function(){};
var NS_WA_onScroll = new function(){};


// page width / height / position functions
function NS_WA_pageWidth() {return window.innerWidth ? window.innerWidth - 27 : document.documentElement && document.documentElement.clientWidth ? document.documentElement.clientWidth : document.body != null ? document.body.clientWidth : null;} 
function NS_WA_pageHeight() {return  window.innerHeight ? window.innerHeight - 7: document.documentElement && document.documentElement.clientHeight ? document.documentElement.clientHeight : document.body != null? document.body.clientHeight : null;} 
function NS_WA_posLeft() {return typeof window.pageXOffset != 'undefined' ? window.pageXOffset :document.documentElement && document.documentElement.scrollLeft ? document.documentElement.scrollLeft : document.body.scrollLeft ? document.body.scrollLeft : 0;} 
function NS_WA_posTop() {return supPositionFixed() ? 0: typeof window.pageYOffset != 'undefined' ? window.pageYOffset: document.documentElement && document.documentElement.scrollTop ? document.documentElement.scrollTop: document.body.scrollTop ? document.body.scrollTop: 0;} 
//
// NS_WA_launchOverlay
// creates the microsite by running the SWF within a DIV overlay
// for Safari only creates a popup because Safari doesn't support transparent layers
//
function NS_WA_launchOverlay() {
	var NS_WA_winW=NS_WA_pageWidth();
	var NS_WA_winH=NS_WA_pageHeight();
	var NS_WA_winL=NS_WA_posLeft();
	var NS_WA_winT=NS_WA_posTop();
	var NS_WA_theAd = document.getElementById('NS_WA_adOverlay');
	//close if the blackout is clicked too incase of issues with Mac Firefox
	if (supPositionFixed()){
		var NS_WA_adContents="<div id='NS_WA_adBlackout' style='background-color:#000000;border:3px solid white;filter:alpha(opacity=75);opacity:0.75;position:fixed;left:"+NS_WA_winL+"px;top:"+NS_WA_winT+"px;width:"+NS_WA_winW+"px;height:"+NS_WA_winH+"px'></div>";
		NS_WA_adContents=NS_WA_adContents+"<div id='NS_WA_adContent' style='margin-top:10px;position:fixed;width:"+NS_WA_siteW+"px;height:"+NS_WA_siteH+"px;left:"+(((NS_WA_winW-NS_WA_siteW)/2)+NS_WA_winL)+"px;top:"+Math.max(NS_WA_winT,((NS_WA_winH-NS_WA_siteH)/2)+NS_WA_winT)+"px;padding:0px;border:2px solid white;vertical-align:center;text-align:center;background-color:white;color:white;'>ad content here</div>";
	} else {
		var NS_WA_adContents="<div id='NS_WA_adBlackout' style='background-color:#000000;border:3px solid white;filter:alpha(opacity=75);opacity:0.75;position:absolute;left:"+NS_WA_winL+"px;top:"+NS_WA_winT+"px;width:"+NS_WA_winW+"px;height:"+NS_WA_winH+"px'></div>";
		NS_WA_adContents=NS_WA_adContents+"<div id='NS_WA_adContent' style='position:absolute;width:"+NS_WA_siteW+"px;height:"+NS_WA_siteH+"px;left:"+(((NS_WA_winW-NS_WA_siteW)/2)+NS_WA_winL)+"px;top:"+Math.max(NS_WA_winT,((NS_WA_winH-NS_WA_siteH)/2)+NS_WA_winT)+"px;padding:0px;border:2px solid white;vertical-align:center;text-align:center;background-color:white;color:white;'>ad content here</div>";
	}
	NS_WA_adContents=NS_WA_adContents+"<div id='NS_WA_adClose' style='z-index:2147483647;width:28px;height:28px;vertical-align:center;position:absolute;left:"+(((NS_WA_winW-NS_WA_siteW)/2)+NS_WA_siteW+NS_WA_winL-11)+"px;top:"+Math.max(NS_WA_winT,((NS_WA_winH-NS_WA_siteH)/2)+NS_WA_winT-10)+"px;padding:0px;' onmouseover='this.style.cursor=\"pointer\";' onmouseout='this.style.cursor=\"default\";' onclick='NS_WA_closeOverlay();'><img style='width:28px;height:28px;border:0;' src='http://m.doubleclick.net/1435809/apple-close.png' /></div>";
	NS_WA_adContents=NS_WA_adContents+"<div id='NS_WA_adSiteName' style='z-index:2147483647;width:600px;height:16px;-moz-border-radius:10px;border-radius:10px;vertical-align:center;position:absolute;left:"+(((NS_WA_winW-NS_WA_siteW)/2)+(NS_WA_siteW-600)/2)+"px;top:"+Math.max(NS_WA_winT,((NS_WA_winH-NS_WA_siteH)/2)+NS_WA_winT-36)+"px;padding:6px;border:2px solid white;background-color:black;color:white;text-align:center;font-style:italic;font-weight:700;font-size:14px;font-family:Arial,Helvetical,Verdana;'>"+NS_WA_AdText+"</div>";
	NS_WA_theAd.innerHTML=NS_WA_adContents;
	
	NS_WA_theAd.style.display='block';
	
	// fill the NS_WA_adContent DIV with the advert.
	// here it's an IFRAME but it could easily be another OBJECT tag holding a SWF
	
	switch (NS_WA_mediaType) {
		case netShelter.media.HTML:
			document.getElementById("NS_WA_adContent").innerHTML='<iframe name="NS_WA_frame1" id="NS_WA_frame1" width="'+NS_WA_siteW+'" height="'+NS_WA_siteH+'" allowtransparency="false" scrolling="no" frameborder="0" src="' + NS_WA_overlayPage + '"></iframe>';
			break;
			
		case netShelter.media.FLASH:
			var NS_WA_sMsSWF = NS_WA_overlayPage + (NS_WA_overlayPage.indexOf("?") == -1 ? "?" : "&") + netShelter.dictToQueryString(NS_WA_flashVars);
			var NS_WA_oAd='<object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0"';
			NS_WA_oAd=NS_WA_oAd+' id="NS_WA_Flash" width="'+NS_WA_siteW+'" height="'+NS_WA_siteH+'">';
			NS_WA_oAd=NS_WA_oAd+'<param name="movie" value="'+NS_WA_sMsSWF+'">';
			NS_WA_oAd=NS_WA_oAd+'<param name="bgcolor" value="#FFFFFF">';
			NS_WA_oAd=NS_WA_oAd+'<param name="quality" value="high">';
			NS_WA_oAd=NS_WA_oAd+'<param name="wmode" value="transparent">';
			NS_WA_oAd=NS_WA_oAd+'<param name="swliveconnect" value="true">';
			NS_WA_oAd=NS_WA_oAd+'<param name="allowscriptaccess" value="always">';
			NS_WA_oAd=NS_WA_oAd+'<param name="allownetworking" value="all">';
			NS_WA_oAd=NS_WA_oAd+'<embed';
			NS_WA_oAd=NS_WA_oAd+' type="application/x-shockwave-flash"';
			NS_WA_oAd=NS_WA_oAd+' pluginspage="http://www.adobe.com/shockwave/download/index.cgi?P1_Prod_Version=ShockwaveFlash"';
			NS_WA_oAd=NS_WA_oAd+' name="NS_WA_Flash"';
			NS_WA_oAd=NS_WA_oAd+' width="'+NS_WA_siteW+'" height="'+NS_WA_siteH+'"';
			NS_WA_oAd=NS_WA_oAd+' src="'+NS_WA_sMsSWF+'"';
			NS_WA_oAd=NS_WA_oAd+' bgcolor="#FFFFFF"';
			NS_WA_oAd=NS_WA_oAd+' swliveconnect="true"';
			NS_WA_oAd=NS_WA_oAd+' wmode="transparent"'; 
			NS_WA_oAd=NS_WA_oAd+' quality="high"';
			NS_WA_oAd=NS_WA_oAd+' allowscriptaccess="always"';
			NS_WA_oAd=NS_WA_oAd+' allownetworking="all"';
			NS_WA_oAd=NS_WA_oAd+'>';
			NS_WA_oAd=NS_WA_oAd+'<noembed>';
			NS_WA_oAd=NS_WA_oAd+'</noembed>';
			NS_WA_oAd=NS_WA_oAd+'</embed>';
			NS_WA_oAd=NS_WA_oAd+'</object>';

			// and write it out onto the page
			document.getElementById("NS_WA_adContent").innerHTML='<center>'+NS_WA_oAd+'</center>';
			break;
			
		case netShelter.media.IMAGE:
			document.getElementById("NS_WA_adContent").innerHTML='<a href = "' + NS_WA_clickPath + '" target="_blank" style="border:0px;"><img src = "' + NS_WA_overlayPage + '" style="border:0px;"/></a>';
			break;
	}
	
	// hook onResize and onScroll events
	NS_WA_onResize=window.onresize;
	window.onresize=NS_WA_resize;
	NS_WA_onScroll=window.onscroll;
	window.onscroll=NS_WA_resize;
	// fix any flash to be wmode transparent
	//NS_WA_fixFlash();
	// launch the overlay
	document.body.appendChild(NS_WA_theAd);
}

// called when the close button is clicked in the minisite
function NS_WA_closeOverlay() {
  // close the overlays
  document.getElementById("NS_WA_adContent").style.display="none";
  document.getElementById("NS_WA_adBlackout").style.display="none";
  document.getElementById("NS_WA_adClose").style.display="none";
  document.getElementById("NS_WA_adOverlay").style.display="none";
  document.getElementById("NS_WA_adSiteName").style.display="none";
  NS_WA_overlayWrite=0;
  // clear down resize functions
  window.onresize=new function(){};
  window.onscroll=new function(){};
}
// onResize handler
function NS_WA_resize() {
  var NS_WA_winW=NS_WA_pageWidth();
  var NS_WA_winH=NS_WA_pageHeight();
  var NS_WA_winT=NS_WA_posTop();
  var NS_WA_winL=NS_WA_posLeft();
  document.getElementById('NS_WA_adBlackout').style.width=NS_WA_winW+"px";
  document.getElementById('NS_WA_adBlackout').style.height=NS_WA_winH+"px";
  document.getElementById('NS_WA_adBlackout').style.top=NS_WA_winT+"px";
  document.getElementById('NS_WA_adBlackout').style.left=NS_WA_winL+"px";
  document.getElementById('NS_WA_adContent').style.left=(((NS_WA_winW-NS_WA_siteW)/2)+NS_WA_winL)+"px";
  document.getElementById('NS_WA_adContent').style.top=Math.max(NS_WA_winT,((NS_WA_winH-NS_WA_siteH)/2)+NS_WA_winT)+"px";
  document.getElementById('NS_WA_adClose').style.left=(((NS_WA_winW-NS_WA_siteW)/2)+NS_WA_siteW+NS_WA_winL-11)+"px";
  document.getElementById('NS_WA_adClose').style.top=Math.max(NS_WA_winT,((NS_WA_winH-NS_WA_siteH)/2)+NS_WA_winT-10)+"px";
  document.getElementById('NS_WA_adSiteName').style.left=(((NS_WA_winW-NS_WA_siteW)/2)+(NS_WA_siteW-600)/2)+"px";
  document.getElementById('NS_WA_adSiteName').style.top=Math.max(NS_WA_winT,((NS_WA_winH-NS_WA_siteH)/2)+NS_WA_winT-36)+"px";
}

function pageHeight() {
	return window.innerHeight ? window.innerHeight: document.documentElement && document.documentElement.clientHeight ? document.documentElement.clientHeight: document.body != null ? document.body.clientHeight: null;
}

function supPositionFixed() {
	var isSupported = null;
	if (document.createElement) {
		var el = document.createElement("div");
		if (el && el.style) {
			el.style.position = "fixed";
			el.style.top = "10px";
			var root = document.body;
			if (root && root.appendChild && root.removeChild) {
				root.appendChild(el);
				isSupported = el.offsetTop === 10;
				root.removeChild(el);
			}
			el = null;
		}
	}
	
	//IE 7 doesn't z-index properly with fixed positioning and transparent wmode 
	return (isSupported && !NS_WA_isIE7());
}

netShelter['dictToQueryString'] = netShelter.dictToQueryString || function(dict) {
	/*	URL encodes a query in the format:
	 *
	 * 	 encodedKey1=encodedValue1&encodedKey2=encodedValue2
	 */

	var encodedPairs = [];

	for (var key in dict) {
		encodedPairs.push(encodeURIComponent(key) + '=' + encodeURIComponent(dict[key]));
	}

	return encodedPairs.join('&');
}

function NS_WA_isIE7() {
	return navigator.userAgent.toLowerCase().indexOf('ie 7') != -1;
}

// launch the overlay
if (supPositionFixed())
	document.write('<div id="NS_WA_adOverlay" style="z-index:2147483646;position:fixed;left:0px;top:0px;width:100%;height:100%;display:none;"></div>');
else
	document.write('<div id="NS_WA_adOverlay" style="z-index:2147483646;position:absolute;left:0px;top:0px;width:100%;height:100%;display:none;"></div>');

NS_WA_launchOverlay();