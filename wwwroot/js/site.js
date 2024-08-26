var isClicked = localStorage.getItem("isClicked") === "true";

function openSearch() {
  document.getElementById("searchInput").style.display = "none";
  document.getElementById("myOverlay").style.display = "block";
  var inputField = document.getElementById("focusSearch");
  inputField.disabled = false;
  inputField.focus();
  isClicked = true; // Set the variable to true
  localStorage.setItem("isClicked",
                       isClicked); // Store the value in localStorage
}

function closeSearch() {
  document.getElementById("searchInput").style.display = "block";
  document.getElementById("myOverlay").style.display = "none";
  isClicked = false; // Reset the variable to false
  localStorage.setItem("isClicked",
                       isClicked); // Store the updated value in localStorage
}

// Function to check if isClicked is true on page load and open the overlay if
// needed
window.onload = function() {
  if (isClicked) {
    openSearch();
  }
};
