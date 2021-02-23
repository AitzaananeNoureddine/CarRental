

function openRightMenu() {
    document.getElementById("rightMenu").style.display = "block";
    document.getElementById("myOverlay").style.display = "block";
}

function closeRightMenu() {
    document.getElementById("rightMenu").style.display = "none";
    document.getElementById("myOverlay").style.display = "none";
}
$('input[type="file"]').change(function (e) {
    var fileName = e.target.files[0].name;
    $('.custom-file-label').html(fileName);
});