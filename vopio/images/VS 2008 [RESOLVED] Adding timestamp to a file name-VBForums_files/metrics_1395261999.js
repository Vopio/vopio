/* This source code is Copyright (c) Vibrant Media 2001-2014 and forms part of the patented Vibrant Media product "IntelliTXT" (sm). */
$iTXT.js.loader["$iTXT.metrics.Events"]=true;$iTXT.metrics.Events_Load=function(){var undefined;$iTXT.metrics.Events=$iTXT.core.Class.create({cOut:true,eventQueue:null,init:function()
{this.eventQueue={};$iTXT.subscribe("$iTXT:metrics:evt",$iTXT.core.Event.bind(this,this._event));$iTXT.subscribe("$iTXT:adlogger:before:log",$iTXT.core.Event.bind(this,this._adlog));},_event:function(e)
{var opts=e.data||{};if(opts.n&&""!=opts.n)
{var evt=this.eventQueue[opts.n];if(null==evt)
{evt=this._createEvt(opts.n,opts.t);this.eventQueue[opts.n]=evt;}
this._updateEvt(evt,opts);}},_updateEvt:function(evt,opts)
{if(evt.t&&"interval"==evt.t)
{if(evt.st)
{evt.et=(new Date()).getTime();evt.done=true;this._log("Interval: "+this._pname(evt.n)+" "+(evt.et-evt.st)+"ms");}
else
{evt.st=(new Date()).getTime();}}
else
{evt.st=this._timeSinceLoad();evt.done=true;this._log("TimeSinceLoad: "+this._pname(evt.n)+" "+(evt.tsl)+"ms");}},_createEvt:function(name,evtType)
{evtType=evtType||"timesince";var evt={n:name,t:evtType,done:false};return evt;},_timeSinceLoad:function()
{return(new Date()).getTime()-$iTXT.js.startTime;},_log:function(msg)
{},_pname:function(n)
{var a={'ll':'Libraries Loaded','tl':'Templates Loaded','intl':'Initialiser Loaded','contl':'Contextualiser Loaded','advl':'Advertiser Loaded','contint':'Contextualiser Interval','advint':'Advertiser Interval'};return a[n];},getEvents:function()
{var retObj={};for(var ename in this.eventQueue)
{var evt=this.eventQueue[ename];if(evt&&evt.done)
{this.eventQueue[ename]=undefined;var evtVal=evt.st;if(evt.et&&""!=evt.et)
{evtVal=evt.et-evt.st;}
retObj[ename]=evtVal;}}
return retObj;},_adlog:function(e)
{var cb=e.data||null;if('function'==typeof cb)
{var evts=this.getEvents(),pEvts=[];for(var n in evts)
{pEvts[pEvts.length]=n+':'+evts[n];}
pEvts=pEvts.join('|');cb({prf:pEvts});}}});};