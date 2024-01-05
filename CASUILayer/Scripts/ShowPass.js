 document.addEventListener("DOMContentLoaded", function () {
        const passwordInput = document.getElementById("Password");
        const showPasswordIcon = document.getElementById("showPasswordIcon");

        showPasswordIcon.addEventListener("click", function () {
            if (passwordInput.type === "password") {
                passwordInput.type = "text";
                showPasswordIcon.textContent = "👁️";
            } else {
                passwordInput.type = "password";
                showPasswordIcon.textContent = "👁️‍🗨️";
            }
        });
    });