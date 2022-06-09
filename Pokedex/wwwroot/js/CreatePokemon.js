function buscarImg() {
    let imgUrl = $("#img-src").val();

    console.log(imgUrl);
    $("#img-show").html(imgUrl == '' ? '<img src="../../img/camera.png" class="img-fluid" style="max-height: 200px; ">':'<img src="' + imgUrl + '" class="img-fluid" style="max-height: 200px; ">')
}