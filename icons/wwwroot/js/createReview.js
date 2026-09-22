function changeImage(imgElement) {
    document.querySelectorAll(".rating-img").forEach(img => {
        const original = img.getAttribute("data-img");
        img.src = "/img/" + original;
    });

    const original = imgElement.getAttribute("data-img");
    imgElement.src = "/img/color-" + original;

    const radio = imgElement.previousElementSibling;
    radio.checked = true;
}