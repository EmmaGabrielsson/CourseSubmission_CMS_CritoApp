document.addEventListener("DOMContentLoaded", function () {

    let subscribeForm, contactForm;
    let emailValid = false;
    let nameValid = false;
    let messageValid = false;

    let validationElements = document.querySelectorAll('[data-val="true"]');
    for (let element of validationElements) {
        element.addEventListener("keyup", function (e) {
            switch (e.target.type) {
                case 'text':
                    nameValid = textValidator(e.target, 2); // Minimum 2 characters for the name
                    break;
                case 'textarea':
                    messageValid = textValidator(e.target, 12); // Minimum 12 characters for the message
                    break;
                case 'email':
                    emailValid = emailValidator(e.target);
                    break;
            }
        });
    }

    contactForm = document.getElementById("contact-form");
    subscribeForm = document.getElementById("subscribe-form");

    if (contactForm != null) {
        contactForm.addEventListener("submit", function (event) {
            event.preventDefault();
            // If validation passes, submit the form
            if (emailValid && nameValid && messageValid) {
                contactForm.submit();
            }
        });
    }

    if (subscribeForm != null) {
        subscribeForm.addEventListener("submit", function (event) {
            event.preventDefault();
            // If validation passes, submit the form
            if (emailValid) {
                subscribeForm.submit();
            }
        });
    }

    function emailValidator(emailInput) {
        const emailRegex = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;

        if (!emailRegex.test(emailInput.value)) {
            emailInput.previousElementSibling.innerHTML = "Invalid email";
            return false;
        } else {
            emailInput.previousElementSibling.innerHTML = "";
            return true;
        }
    }

    function textValidator(target, minLength) {
        if (target.value.length < minLength) {
            document.getElementById(`${target.id}`).previousElementSibling.innerHTML = "Too short, invalid input";
            return false;
        } else {
            document.getElementById(`${target.id}`).previousElementSibling.innerHTML = "";
            return true;
        }
    }
});
