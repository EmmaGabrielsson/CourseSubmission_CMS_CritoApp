
let validationElements = document.querySelectorAll('[data-val="true"]')

for (let element of validationElements) {
    element.addEventListener("keyup", function (e) {
        switch (e.target.type) {
            case 'text':
                textValidator(e.target, 2)
                break;
            case 'textarea':
                textValidator(e.target, 12)
                break;
            case 'email':
                emailValidator(e.target)
                break;
        }
    })
}

function textValidator(target, minLength) {
    if (target.value.length < minLength) {

        document.getElementById(`${target.id}`).previousElementSibling.innerHTML = "Too short, invalid input"
    }
    else
        document.getElementById(`${target.id}`).previousElementSibling.innerHTML = ""
}

function emailValidator(target) {
    const emailRegex = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;

    if (!emailRegex.test(target.value))
        document.getElementById(`${target.id}`).previousElementSibling.innerHTML = "invalid email"
    else
        document.getElementById(`${target.id}`).previousElementSibling.innerHTML = ""
}

