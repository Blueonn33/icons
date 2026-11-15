function burn(button) {
    const note = button.closest(".note-partial-container");
    const noteBody = note.querySelector(".note-body");
    const form = button.closest("form");

    button.disabled = true;
    const finishBurn = event => {
        if (event.animationName === "burn-background") {
            noteBody.removeEventListener("animationend", finishBurn);
            form.requestSubmit();
        }
    };

    noteBody.addEventListener("animationend", finishBurn);

    noteBody.classList.add("burn");
}