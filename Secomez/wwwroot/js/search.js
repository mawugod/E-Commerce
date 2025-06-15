function searchItems() {


    //declares variables for the input element, the filter text, and variables used in the loop.
    var input, filter, cards, card, title, i;
    // Get the input element and its value
    input = document.getElementById("searchInput");
    //Converts filter to uppercase
    filter = input.value.toUpperCase();


    // Get all elements with the class "card" within the "itemList" container

    cards = document.getElementById("itemList").getElementsByClassName("card");

    // Loop through each card element

    for (i = 0; i < cards.length; i++) {

        // Get the title element within the current card

        title = cards[i].getElementsByClassName("card-title")[0];

        // If the title matches, display the card

        if (title.innerHTML.toUpperCase().indexOf(filter) > -1) {
            cards[i].style.display = "";
        } else {
            // If the title does not match, hide the card

            cards[i].style.display = "none";
        }
    }
}