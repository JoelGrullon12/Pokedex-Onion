function filter() {
    let region = $("#region-filter").val()
    let domain = window.location
    let key = "?region="

    window.location.replace(domain + key + region);
    
}