function burn(button) {
    const note = button.closest(".note-partial-container");
    note.querySelector("#note-body").classList.add("burn");
}