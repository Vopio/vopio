var brandFooterArray = {"forums.databasejournal.com":"itbeBrandForum-footer","forums.datamation.com":"itbeBrandForum-footer","forums.serverwatch.com":"itbeBrandForum-footer","discussions.virtualdr.com":"itbeBrandForum-footer","forums.windrivers.com":"itbeBrandForum-footer","forums.windrivers.com/vb/":"itbeBrandForum-footer","www.sharkyforums.com":"itbeBrandForum-footer","www.sysopt.com/forum/":"itbeBrandForum-footer","forums.practicallynetworked.com":"itbeBrandForum-footer","discussions.hardwarecentral.com":"itbeBrandForum-footer","forums.enterpriseitplanet.com":"itbeBrandForum-footer","forums.dbasupport.com/forums/":"itbeBrandForum-footer","www.dbasupport.com/forums/":"itbeBrandForum-footer","www.pdastreet.com/forums/":"itbeBrandForum-footer","forums.smallbusinesscomputing.com":"itbeBrandForum-footer","www.antionline.com":"itbeBrandForum-footer","downloads.antionline.com":"itbeBrandForum-footer","www.codeguru.com/forum/":"developerBrandForum-footer","forums.codeguru.com":"developerBrandForum-footer","www.phpbuilder.com/board/":"developerBrandForum-footer","board.flashkit.com/board/":"developerBrandForum-footer","forums.devx.com":"developerBrandForum-footer","www.aspmessageboard.com":"developerBrandForum-footer","www.vbforums.com":"developerBrandForum-footer","www.databasejournal.com":"itbeBrand-footer","www.datamation.com":"itbeBrand-footer","www.serverwatch.com":"itbeBrand-footer","www.infostor.com":"itbeBrand-footer","premium.windrivers.com":"itbeBrand-footer","www.windrivers.com":"itbeBrand-footer","www.sharkyextreme.com":"itbeBrand-footer","www.sysopt.com":"itbeBrandForum-footer","www.practicallynetworked.com":"itbeBrand-footer","www.hardwarecentral.com":"itbeBrandForum-footer","www.sqlcourse.com":"itbeBrand-footer","www.sqlcourse2.com":"itbeBrand-footer","www.linuxplanet.com":"itbeBrand-footer","www.ecommerce-guide.com":"itbeBrand-footer","www.enterprisemobiletoday.com":"itbeBrand-footer","forums.enterprisemobiletoday.com":"itbeBrandForum-footer","www.enterprisestorageforum.com":"itbeBrand-footer","www.itsmwatch.com":"itbeBrand-footer","www.itchannelplanet.com":"itbeBrand-footer","www.enterpriseitplanet.com":"itbeBrand-footer","www.xmlfiles.com":"itbeBrand-footer","www.projectmanagerplanet.com":"itbeBrand-footer","www.dbasupport.com":"itbeBrand-footer","www.linux-mag.com":"itbeBrand-footer","www.linuxtoday.com":"itbeBrand-footer","www.internetnews.com":"itbeBrand-footer","www.pdastreet.com":"itbeBrand-footer","www.webopedia.com":"itbeBrand-footer","new.webopedia.com":"itbeBrand-footer","www.smallbusinesscomputing.com":"itbeBrand-footer","www.enterprisenetworkingplanet.com":"itbeBrand-footer","www.esecurityplanet.com":"itbeBrand-footer","www.cioupdate.com":"itbeBrand-footer","www.enterpriseappstoday.com":"enterpriseappstoday-footer","www.earthweb.com":"itbeBrand-footer","www.wi-fiplanet.com":"itbeBrand-footer","forums.wi-fiplanet.com":"itbeBrandForum-footer","www.codeguru.com":"developerBrand-footer","www.phpbuilder.com":"developerBrand-footer","www.javascriptsource.com":"developerBrand-footer","www.javascript.internet.com":"developerBrand-footer","www.4guysfromrolla.com":"developerBrand-footer","www.webdevelopersjournal.com":"developerBrand-footer","www.javaboutique.com":"developerBrand-footer","www.sharepointbriefing.com":"developerBrand-footer","www.webreference.com":"developerBrand-footer","www.htmlgoodies.com":"developerBrand-footer","www.scriptsearch.com":"developerBrand-footer","www.flashkit.com":"developerBrand-footer","www.jguru.com":"developerBrand-footer","www.freevbcode.com":"developerBrand-footer","www.justtechjobs.com":"developerBrand-footer","www.linuxtoday.justtechjobs.com":"developerBrand-footer","www.dbasupport.justtechjobs.com":"developerBrand-footer","www.flashkit.justtechjobs.com":"developerBrand-footer","www.phpbuilder.justtechjobs.com":"developerBrand-footer","www.webdeveloper.justtechjobs.com":"developerBrand-footer","www.webreference.justtechjobs.com":"developerBrand-footer","www.dbjournal.justtechjobs.com":"developerBrand-footer","www.devx.com":"developerBrand-footer","www.webdeveloper.com":"developerBrandForum-footer","www.developer.com":"developerBrand-footer", "www.justlinux.com/forum":"itbeBrandForum-footer", "www.justlinux.com":"itbeBrand-footer","videos.developer.com/video/":"developerBrand-footer","www.videos.developer.com/video/":"developerBrand-footer","www.freelancer.internet.com":"itbeBrand-footer","www.freelancer.itbusinessedge.com":"itbeBrand-footer","www.partners.itbusinessedge.com":"itbeBrand-footer","partners.itbusinessedge.com":"itbeBrand-footer","e-newsletters.developer.com":"developerBrand-footer","e-newsletters.itbusinessedge.com":"itbeBrand-footer","board.phpbuilder.com/":"developerBrandForum-footer","www.itbusinessedge.com":"itbeBrand-footer","www.ziffdavisenterprise.com":"zde-footer","www.baselinemag.com":"baseline-footer","www.channelinsider.com":"cinsider-footer","www.cioinsight.com":"cioinsight-footer","www.eweek.com":"eweek-footer","www.webbuyersguide.com":"wbg-footer","e-newsletters.ziffdavisenterprise.com":"zde-footer","blogs.baselinemag.com":"baseline-footer","blogs.cioinsight.com":"cioinsight-footer","www.eseminarslive.com":"eseminar-footer"};

var siteURL = window.location;
siteURL = siteURL.toString();
var siteName = window.location.hostname;
siteName = siteName.toLowerCase();
var showBrandFooter = "";
var siteNameArray = "";
var today4Footer = new Date();

for (key in brandFooterArray){
    showBrandFooter = brandFooterArray[key];
	if(showBrandFooter!="NoToolbar"){
		if(showBrandFooter=="developerBrandForum-footer" || showBrandFooter=="itbeBrandForum-footer"){
				if(siteName.indexOf(".lampdev.dms.quinstreet.net") >= 0){
					 siteNameArray = siteName.split('.lampdev.dms.quinstreet.net'); 
					 if(siteNameArray[0].indexOf("www.") != 0)
					 siteName  = "www."+siteNameArray[0];
					//console.log("Lampdev site name"+siteName);

				}
			
				// Clean up dev urls
				if ( siteName.indexOf("dev-") >= 0 ) {
					siteNameArray = siteName.split('dev-'); 
					siteName = siteNameArray[1];
				}
				
				// Clean up local urls
				if ( siteName.indexOf("local.") >= 0 ) {
					siteNameArray = siteName.split('local.'); 
					siteName = siteNameArray[1];
				}
				
				if(siteName.indexOf("videos.") < 0 && siteName.indexOf("downloads.") < 0 && siteName.indexOf("forums.") < 0 && siteName.indexOf("discussions.") < 0 && siteName.indexOf("premium.") < 0 && siteName.indexOf("www.") < 0) {
					siteName  = "www."+siteName;
				}
				
				// check siteURL for url forum sites
				if ( siteURL.indexOf("http://") >= 0 ) {
					siteURLArray = siteURL.split('http://'); 
					siteURL  = siteURLArray[1];
				}

				// Clean up dev urls
				if ( siteURL.indexOf("dev-") >= 0 ) {
					siteURLArray = siteURL.split('dev-'); 
					siteURL = siteURLArray[1];
				}

				if(siteURL.indexOf("videos.") < 0 && siteURL.indexOf("downloads.") < 0 && siteURL.indexOf("forums.") < 0 && siteURL.indexOf("discussions.") < 0 && siteURL.indexOf("premium.") < 0  && siteURL.indexOf("www.") < 0) {
					siteURL  = "www."+siteURL;
				}

				domainSearch=new RegExp(key);
				if (domainSearch.test(siteName) == true || domainSearch.test(siteURL) == true){
					document.getElementById(showBrandFooter).style.display="";
					if(showBrandFooter=='itbeBrandForum-footer'){
						document.getElementById(showBrandFooter).innerHTML = '<div id="acceptableusepolicy" style="margin-bottom:5px;"><a href="/aup.html" style="color: #000000;">Acceptable Use Policy</a></div><div id="itbeforumlogo"><a href="http://www.itbusinessedge.com" target="_blank"><img src="/icom_includes/footers/img/itbe.gif" border="0" /></a></div>'+
						'<div id="footercopyright"> Property of Quinstreet Enterprise. </div><div id="footerlinks"><a href="/terms">Terms of Service</a> | <a href="/licensing">Licensing & Reprints</a> | <a href="/privacy">Privacy Policy</a> | <a href="http://quinstreetenterprise.com/about_us#contactus" target="_blank">Advertise</a><br>Copyright '+today4Footer.getFullYear()+' QuinStreet Inc. All Rights Reserved.<noscript>Copyright 2013 Quinstreet Inc. All right reserved.<noscript></div>';
					}
					else if(showBrandFooter=='developerBrandForum-footer'){	
						document.getElementById(showBrandFooter).innerHTML = '<div id="acceptableusepolicy" style="margin-bottom:5px;"><a href="/aup.html" target="_blank" style="color: #000000;">Acceptable Use Policy</a></div><div id="developerforumlogo"><a href="http://www.developer.com" target="_blank"><img src="/icom_includes/footers/img/developer_logo.jpg" border="0" /></a></div>'+
						'<div id="footercopyright"> Property of Quinstreet Enterprise. </div><div id="footerlinks"><a href="/terms">Terms of Service</a> | <a href="/licensing">Licensing & Reprints</a> | <a href="/privacy">Privacy Policy</a> | <a href="http://quinstreetenterprise.com/about_us#contactus" target="_blank">Advertise</a><br>Copyright '+today4Footer.getFullYear()+' QuinStreet Inc. All Rights Reserved.<noscript>Copyright 2013 Quinstreet Inc. All right reserved.<noscript></div>';
					}						
					break;
				}
		}
		else if(showBrandFooter!="developerBrandForum-footer" && showBrandFooter!="itbeBrandForum-footer"){
			domainSearch=new RegExp(key);

			if(siteName.indexOf("downloads.") < 0 && siteName.indexOf("board.") < 0 && siteName.indexOf("forums.") < 0 && siteName.indexOf("blogs.") < 0 && siteName.indexOf("discussions.") < 0 && siteURL.indexOf("/board/") < 0 && siteURL.indexOf("/forum/") < 0 && siteURL.indexOf("/forums/") < 0 && siteName.indexOf(".lampdev.dms.quinstreet.net") >= 0){
				 siteNameArray = siteName.split('.lampdev.dms.quinstreet.net'); 
				 if(siteNameArray[0].indexOf("www.") != 0)
				 siteName  = "www."+siteNameArray[0];
			 }
		
			if(siteName.indexOf("downloads.") < 0 && siteName.indexOf("board.") < 0 && siteName.indexOf("forums.") < 0 && siteName.indexOf("blogs.") < 0 && siteName.indexOf("discussions.") < 0 && siteURL.indexOf("/board/") < 0 && siteURL.indexOf("/forum/") < 0 && siteURL.indexOf("/forums/") < 0 && (siteName.indexOf("dev-") == 0 || siteName.indexOf("js.") == 0 || siteName.indexOf("videos.") == 0)){
			
			if(siteName.indexOf("js.") == 0)
				siteNameArray = siteName.split('js.'); 
			else if(siteName.indexOf("videos.") == 0)
				siteNameArray = siteName.split('videos.'); 
			else
				siteNameArray = siteName.split('dev-'); 
				
				if(siteNameArray[1].indexOf("www.") !=  0){
				 siteName  = "www."+siteNameArray[1];
			   }
			}
			
			if(siteName.indexOf("downloads.") < 0 && siteName.indexOf("board.") < 0 && siteName.indexOf("forums.") < 0 && siteName.indexOf("blogs.") < 0 && siteName.indexOf("discussions.") < 0 && siteURL.indexOf("/board/") < 0 && siteURL.indexOf("/forum/") < 0 && siteURL.indexOf("/forums/") < 0 && siteName.indexOf("dev.") == 0){
				siteNameArray = siteName.split('dev.'); 
				if(siteNameArray[1].indexOf("www.") != 0){
				 siteName  = "www."+siteNameArray[1];
			   }
			}

			if(siteName.indexOf("downloads.") < 0 && siteName.indexOf("board.") < 0 && siteName.indexOf("forums.") < 0 && siteName.indexOf("blogs.") < 0 && siteName.indexOf("discussions.") < 0 && siteURL.indexOf("/board/") < 0 && siteURL.indexOf("/forum/") < 0 && siteURL.indexOf("/forums/") < 0 && siteName.indexOf("local.") == 0){
				siteNameArray = siteName.split('local.'); 
				if(siteNameArray[1].indexOf("www.") != 0){
				 siteName  = "www."+siteNameArray[1];
			   }
			}
			
			if(siteName.indexOf("downloads.") < 0 && siteName.indexOf("board.") < 0 && siteName.indexOf("forums.") < 0 && siteName.indexOf("blogs.") < 0 && siteName.indexOf("discussions.") < 0 && siteURL.indexOf("/board/") < 0 && siteURL.indexOf("/forum/") < 0 && siteURL.indexOf("/forums/") < 0 && siteName.indexOf("cms.") == 0){
				siteNameArray = siteName.split('cms.'); 
				if(siteNameArray[1].indexOf("www.") != 0){
				 siteName  = "www."+siteNameArray[1];
			   }
			}
			
			if(siteName.indexOf("downloads.") < 0 && siteName.indexOf("board.") < 0 && siteName.indexOf("forums.") < 0 && siteName.indexOf("blogs.") < 0 && siteName.indexOf("discussions.") < 0 && siteURL.indexOf("/board/") < 0 && siteURL.indexOf("/forum/") < 0 && siteURL.indexOf("/forums/") < 0){
			   if(siteName.indexOf("www.") != 0){
				 siteName  = "www."+siteName ;
			   }
			}
			
			if (domainSearch.test(siteName) == true){
				if(showBrandFooter!="" || showBrandFooter !="undefined"){
					document.getElementById(showBrandFooter).style.display="";
					if(showBrandFooter=='baseline-footer'){
						document.getElementById(showBrandFooter).innerHTML = '<div><img src="/icom_includes/footers/img/baselinemag.png" border="0" /> </div><div id="footercopyright"> Property of Quinstreet Enterprise. </div><div id="footerlinks"><a href="/terms">Terms of Service</a> | <a href="/licensing">Licensing & Reprints</a> | <a href="/privacy">Privacy Policy</a> | <a href="http://quinstreetenterprise.com/about_us#contactus" target="_blank">Advertise</a><br>Copyright '+today4Footer.getFullYear()+' QuinStreet Inc. All Rights Reserved.<noscript>Copyright 2013 Quinstreet Inc. All right reserved.<noscript></div>';	
					}
					else if(showBrandFooter=='wbg-footer'){
						document.getElementById(showBrandFooter).innerHTML = '<div><img src="/icom_includes/footers/img/wbg.png" border="0" /></div><div id="footercopyright"> Property of Quinstreet Enterprise. </div><div id="footerlinks"><a href="/terms">Terms of Service</a> | <a href="/licensing">Licensing & Reprints</a> | <a href="/privacy">Privacy Policy</a> | <a href="http://quinstreetenterprise.com/about_us#contactus" target="_blank">Advertise</a><br>Copyright '+today4Footer.getFullYear()+' QuinStreet Inc. All Rights Reserved.<noscript>Copyright 2013 Quinstreet Inc. All right reserved.<noscript></div>';	
					}
					else if(showBrandFooter=='eweek-footer'){		
						document.getElementById(showBrandFooter).innerHTML = '<div><img src="/icom_includes/footers/img/eweek.png" border="0" /></div><div id="footercopyright"> Property of Quinstreet Enterprise. </div><div id="footerlinks"><a href="/terms">Terms of Service</a> | <a href="/licensing">Licensing & Reprints</a> | <a href="/privacy">Privacy Policy</a> | <a href="http://quinstreetenterprise.com/about_us#contactus" target="_blank">Advertise</a><br>Copyright '+today4Footer.getFullYear()+' QuinStreet Inc. All Rights Reserved.<noscript>Copyright 2013 Quinstreet Inc. All right reserved.<noscript></div>';	
					}
					else if(showBrandFooter=='cioinsight-footer'){		
						document.getElementById(showBrandFooter).innerHTML = '<div><img src="/icom_includes/footers/img/cioinsight.png" border="0" /></div><div id="footercopyright"> Property of Quinstreet Enterprise. </div><div id="footerlinks"><a href="/terms">Terms of Service</a> | <a href="/licensing">Licensing & Reprints</a> | <a href="/privacy">Privacy Policy</a> | <a href="http://quinstreetenterprise.com/about_us#contactus" target="_blank">Advertise</a><br>Copyright '+today4Footer.getFullYear()+' QuinStreet Inc. All Rights Reserved.<noscript>Copyright 2013 Quinstreet Inc. All right reserved.<noscript></div>';	
					}
					else if(showBrandFooter=='cinsider-footer'){		
						document.getElementById(showBrandFooter).innerHTML = '<div><img src="/icom_includes/footers/img/cioinsider.png" border="0" /></div><div id="footercopyright"> Property of Quinstreet Enterprise. </div><div id="footerlinks"><a href="/terms">Terms of Service</a> | <a href="/licensing">Licensing & Reprints</a> | <a href="/privacy">Privacy Policy</a> | <a href="http://quinstreetenterprise.com/about_us#contactus" target="_blank">Advertise</a><br>Copyright '+today4Footer.getFullYear()+' QuinStreet Inc. All Rights Reserved.<noscript>Copyright 2013 Quinstreet Inc. All right reserved.<noscript></div>';	
					}	
					else if(showBrandFooter=='zde-footer'){		
						document.getElementById(showBrandFooter).innerHTML = '<div><img src="/icom_includes/footers/img/zde.png" border="0" /></div><div id="footercopyright"> Property of Quinstreet Enterprise. </div><div id="footerlinks"><a href="/terms">Terms of Service</a> | <a href="/licensing">Licensing & Reprints</a> |'+
					' <a href="http://quinstreetenterprise.com/about_us" target="_blank">About Us</a> |  <a href="/privacy">Privacy Policy</a>  | <a href="http://quinstreetenterprise.com/about_us#contactus" target="_blank">Advertise</a><br>Copyright '+today4Footer.getFullYear()+' QuinStreet Inc. All Rights Reserved.<noscript>Copyright 2013 Quinstreet Inc. All right reserved.<noscript></div>';	
					}
					else if(showBrandFooter=='enterpriseappstoday-footer'){		
						document.getElementById(showBrandFooter).innerHTML = '<div id="itbelogo"><img src="/icom_includes/footers/img/itbe.gif" border="0" /></div><div id="footercopyright"> Property of Quinstreet Enterprise. </div><div id="footerlinks"><a href="/terms">Terms of Service</a> | <a href="/licensing">Licensing & Reprints</a> | <a href="/about-us">About Us</a> |  <a href="/privacy">Privacy Policy</a> | <a href="http://quinstreetenterprise.com/about_us#contactus" target="_blank">Advertise</a><br>Copyright '+today4Footer.getFullYear()+' QuinStreet Inc. All Rights Reserved.<noscript>Copyright 2013 Quinstreet Inc. All right reserved.<noscript></div>';	
					}	
					else if(showBrandFooter=='eseminar-footer'){		
						document.getElementById(showBrandFooter).innerHTML = '<div><a href="http://www.eseminarslive.com" target="_blank"><img src="/icom_includes/footers/img/eseminarslive.png" border="0" /></a></div><div id="footercopyright"> Property of Quinstreet Enterprise. </div><div id="footerlinks"><a href="/terms">Terms of Service</a> | <a href="/licensing">Licensing & Reprints</a> | <a href="/privacy">Privacy Policy</a>  | <a href="http://quinstreetenterprise.com/about_us#contactus" target="_blank">Advertise</a><br>Copyright '+today4Footer.getFullYear()+' QuinStreet Inc. All Rights Reserved.<noscript>Copyright 2013 Quinstreet Inc. All right reserved.<noscript></div>';	
					}					
					else if(showBrandFooter=='developerBrand-footer'){	
						document.getElementById(showBrandFooter).innerHTML = '<div id="developerlogo"><img src="/icom_includes/footers/img/developer_logo.jpg" border="0" /></div><div id="footercopyright"> Property of Quinstreet Enterprise. </div><div id="footerlinks"><a href="/terms">Terms of Service</a> | <a href="/licensing">Licensing & Reprints</a> | <a href="http://quinstreetenterprise.com/about_us" target="_blank">About Us</a> | <a href="/privacy">Privacy Policy</a> | <a href="http://quinstreetenterprise.com/about_us#contactus" target="_blank">Advertise</a><br>Copyright '+today4Footer.getFullYear()+' QuinStreet Inc. All Rights Reserved.<noscript>Copyright 2013 Quinstreet Inc. All right reserved.<noscript></div>';	
					}
					else if(showBrandFooter=='itbeBrandForum-footer'){	
						document.getElementById(showBrandFooter).innerHTML = '<div id="acceptableusepolicy" style="margin-bottom:5px;color: #000000;"><a href="/aup.html" style="color: #000000;">Acceptable Use Policy</a></div><div id="itbeforumlogo"><a href="http://www.itbusinessedge.com" target="_blank"><img src="/icom_includes/footers/img/itbe.gif" border="0" /></a></div>'+
						'<div id="footercopyright"> Property of Quinstreet Enterprise. </div><div id="footerlinks"><a href="/terms">Terms of Service</a> | <a href="/licensing">Licensing & Reprints</a> | <a href="/privacy">Privacy Policy</a> | <a href="http://quinstreetenterprise.com/about_us#contactus" target="_blank">Advertise</a><br>Copyright '+today4Footer.getFullYear()+' QuinStreet Inc. All Rights Reserved.<noscript>Copyright 2013 Quinstreet Inc. All right reserved.<noscript></div>';
					}
					else if(showBrandFooter=='developerBrandForum-footer'){	
						document.getElementById(showBrandFooter).innerHTML = '<div id="acceptableusepolicy" style="margin-bottom:5px;"><a href="/aup.html" target="_blank" style="color: #000000;">Acceptable Use Policy</a></div><div id="developerforumlogo"><a href="http://www.developer.com" target="_blank"><img src="/icom_includes/footers/img/developer_logo.jpg" border="0" /></a></div>'+
						'<div id="footercopyright"> Property of Quinstreet Enterprise. </div><div id="footerlinks"><a href="/terms">Terms of Service</a> | <a href="/licensing">Licensing & Reprints</a> | <a href="/privacy">Privacy Policy</a> | <a href="http://quinstreetenterprise.com/about_us#contactus" target="_blank">Advertise</a><br>Copyright '+today4Footer.getFullYear()+' QuinStreet Inc. All Rights Reserved.<noscript>Copyright 2013 Quinstreet Inc. All right reserved.<noscript></div>';
					}					
					else{
						document.getElementById("itbeBrand-footer").innerHTML = '<div id="itbelogo"><img src="/icom_includes/footers/img/itbe.gif" border="0" /></div><div id="footercopyright"> Property of Quinstreet Enterprise. </div><div id="footerlinks"><a href="/terms">Terms of Service</a> | <a href="/licensing">Licensing & Reprints</a> | <a href="http://quinstreetenterprise.com/about_us" target="_blank">About Us</a> |  <a href="/privacy">Privacy Policy</a> | <a href="http://quinstreetenterprise.com/about_us#contactus" target="_blank">Advertise</a><br>Copyright '+today4Footer.getFullYear()+' QuinStreet Inc. All Rights Reserved.<noscript>Copyright 2013 Quinstreet Inc. All right reserved.<noscript></div>';	
				}
		
					
				}else{
				    document.getElementById("itbeBrand-footer").style.display="";
				   	document.getElementById("itbeBrand-footer").innerHTML = '<div id="itbelogo"><img src="/icom_includes/footers/img/itbe.gif" border="0" /></div><div id="footercopyright"> Property of Quinstreet Enterprise. </div><div id="footerlinks"><a href="/terms">Terms of Service</a> | <a href="/licensing">Licensing & Reprints</a> | <a href="http://quinstreetenterprise.com/about_us" target="_blank">About Us</a> | <a href="/privacy">Privacy Policy</a> | <a href="http://quinstreetenterprise.com/about_us#contactus" target="_blank">Advertise</a><br>Copyright '+today4Footer.getFullYear()+' QuinStreet Inc. All Rights Reserved.<noscript>Copyright 2013 Quinstreet Inc. All right reserved.<noscript></div>';		
				}
				break;
			}
		}
	}
	
}
