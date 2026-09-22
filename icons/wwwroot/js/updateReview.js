function openUpdateModal(button) {
    const id = button.getAttribute("data-id");
    const title = button.getAttribute("data-title");
    const description = button.getAttribute("data-description");

    document.getElementById("review-id").value = id;
    document.getElementById("review-title").value = title;
    document.getElementById("review-description").value = description;

    var modal = new bootstrap.Modal(document.getElementById("update-review-modal"));
    modal.show();
}