let quotes = [
    "Stephane Nappo: It takes 20 years to build a reputation and a few minutes of a cyber-incident to ruin it.",
    "Richard Clarke: If you spend more on coffee than on IT security, you will be hacked. What is more, you deserve to be hacked."
];

let images = [
    "/img/slides/antivirus.jpg",
    "/img/slides/slide.jpeg"

];

let currentIndex = 0;

function updateSlide() {
    let element = document.querySelector(".quote");
    let imageElement = document.querySelector(".slid");

    // Set the text and image without checking for undefined
    element.textContent = quotes[currentIndex];
    imageElement.src = images[currentIndex];

    currentIndex = (currentIndex + 1) % quotes.length;
}

// Initial call to updateSlide
updateSlide();

// Set interval for continuous sliding
setInterval(updateSlide, 5000);
