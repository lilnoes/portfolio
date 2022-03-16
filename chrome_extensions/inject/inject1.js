(function () {
  let script = document.createElement("script");
  script.type = "text/javascript";
  script.src =
    "https://cdnjs.cloudflare.com/ajax/libs/html2canvas/1.4.1/html2canvas.min.js";
  document.head.appendChild(script);
  console.log("injected 1");
})();
