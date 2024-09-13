var isClicked = localStorage.getItem("isClicked") === "true";
var isUrlCaptured = localStorage.getItem("isUrlCaptured") === "true";
var currentUrl; // Declare currentUrl in global scope

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
}

// Function to check if isClicked is true on page load and open the overlay if
// needed
window.onload = function() {
  if (isClicked) {
    openSearch();
  }
};
