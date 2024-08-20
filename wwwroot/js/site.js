// Please see documentation at
// https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web
// assets.

// Write your JavaScript code.
function openSearch() {
  document.getElementById("searchInput").style.display = "none";
  // Make the fake search desapear
  document.getElementById("myOverlay").style.display = "block";
  // Appear the fullscreen

  var inputField = document.getElementById("focusSearch");
  inputField.disabled = false; // Make the input field enabled
  inputField.focus();          // Focus on the input field
}

function closeSearch() {
  document.getElementById("myOverlay").style.display = "none";
  // Disable the full screen
  document.getElementById("searchInput").style.display = "block";
  // Reappear the fake search
}
