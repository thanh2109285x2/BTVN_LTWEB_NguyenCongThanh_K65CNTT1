document.querySelectorAll('.navbar-nav .nav-link').forEach(link => {
    if (link.pathname === window.location.pathname){
        link.classList.add('active');
    }
});