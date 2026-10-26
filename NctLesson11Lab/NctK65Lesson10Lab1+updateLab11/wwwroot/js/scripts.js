document.addEventListener('DOMContentLoaded', function () {
    var btn = document.getElementById('sidebarToggle');
    if (btn) {
        btn.addEventListener('click', function (e) {
            e.preventDefault();
            document.body.classList.toggle('sb-sidenav-toggled');
        });
    }
});