var isClicked = localStorage.getItem("isClicked") === "true";
var isUrlCaptured = localStorage.getItem("isUrlCaptured") === "true";
var currentUrl; // Declare currentUrl in global scope
var searchPerformed = localStorage.getItem("searchPerformed") ===
                      "true"; // Track if search has been performed
// Fonction pour ajouter/enlever la classe "strikethrough" au texte associé à la
// checkbox
function toggleStrikethrough(checkbox) {
  var text = checkbox.nextElementSibling;
  if (checkbox.checked) {
    text.classList.add("strikethrough");
  } else {
    text.classList.remove("strikethrough");
  }
}
function openSearch() {
  document.getElementById("searchInput").style.display = "none";
  document.getElementById("myOverlay").style.display = "block";
  var inputField = document.getElementById("focusSearch");

  // Capture the URL only if it hasn't been captured yet
  if (!isUrlCaptured) {
    currentUrl = window.location.href; // Capture the current page URL
    localStorage.setItem("currentUrl",
                         currentUrl); // Store the URL in localStorage
    localStorage.setItem("isUrlCaptured", "true"); // Mark URL as captured
  } else {
    // Retrieve the URL from localStorage if it has already been captured
    currentUrl = localStorage.getItem("currentUrl");
  }

  inputField.disabled = false;
  inputField.focus();
  isClicked = true; // Set the variable to true
  localStorage.setItem("isClicked",
                       isClicked); // Store the value in localStorage

  // Check if search has already been performed
  if (!searchPerformed) {
    performSearch();                                 // Call the search function
    localStorage.setItem("searchPerformed", "true"); // Mark search as performed
  }
}

function performSearch() {
  // Trigger the search form submission programmatically
  document.getElementById("searchForm").submit();
}

function closeSearch() {
  window.location.href = currentUrl; // Redirect to the stored URL
  document.getElementById("searchInput").style.display = "block";
  document.getElementById("myOverlay").style.display = "none";
  isClicked = false; // Reset the variable to false
  localStorage.setItem("isClicked",
                       isClicked); // Store the updated value in localStorage

  // Reset URL and flag
  localStorage.removeItem("currentUrl");
  localStorage.removeItem("isUrlCaptured");
  localStorage.removeItem("searchPerformed"); // Reset search performed status
}

// Function to check if isClicked is true on page load and open the overlay if
// needed
window.onload = function() {
  if (isClicked) {
    openSearch();
  }
};
