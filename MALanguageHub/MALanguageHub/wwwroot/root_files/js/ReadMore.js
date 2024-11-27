// JavaScript to handle the description toggle for courses, professionals, and testimonials
document.querySelectorAll('.toggle-description').forEach(function (toggle) {
    toggle.addEventListener('click', function (event) {
        event.stopPropagation(); // Prevent click from bubbling up to document
        const descriptionElement = this.previousElementSibling;
        const fullDescription = descriptionElement.getAttribute('data-full');

        // Show full description
        descriptionElement.innerText = fullDescription; // Show full description
        this.innerText = 'Read less'; // Change link text

        // Add a click listener to the document to revert back to short description
        const revertDescription = function () {
            const isCourseDescription = descriptionElement.classList.contains('course-description');
            const isProfessionalDescription = descriptionElement.classList.contains('professional-description');
            const shortDesc = isCourseDescription
                ? fullDescription.substring(0, 40) + "..."
                : isProfessionalDescription
                    ? fullDescription.substring(0, 26) + "..."
                    : fullDescription.substring(0, 16) + "..."; // Default for testimonials

            descriptionElement.innerText = shortDesc; // Show short description
            toggle.innerText = 'Read more'; // Change link text back
            document.removeEventListener('click', revertDescription); // Remove listener after reverting
        };

        document.addEventListener('click', revertDescription);
    });
});