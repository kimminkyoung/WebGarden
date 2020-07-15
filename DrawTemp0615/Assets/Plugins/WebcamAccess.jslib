// JavaScript source code

mergeInto(LibraryManager.library, {

 WebcamAllow: function(){
    window.alert("not supported");

    if (!navigator.getUserMedia){
       alert("Try supported");
    navigator.getUserMedia({video: true});
    }

    if(navigator.getUserMedia){
    alert("supported");
    navigator.getUserMedia({video: true});
    }

 }


});