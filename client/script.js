const InputType = {
    password: "password",
    email: "email",
    firstName: "firstName",
    lastName: "lastName"
  };
  
  //Used for tracking signup request state
  let waitingForRequest = false;
  
  const firstNameValidation = document.getElementById('firstNameValidation');
  const lastNameValidation = document.getElementById('lastNameValidation');
  const emailValidation = document.getElementById('emailValidation');
  const signupButton = document.getElementById('signupButton');
  const firstNameInput = document.getElementById('firstName');
  const lastNameInput = document.getElementById('lastName');
  const emailInput = document.getElementById('emailAddress');
  const passwordInput = document.getElementById('password');
  const confirmPasswordInput = document.getElementById('confirmPassword');
  
  function getFormData() {
    const firstName = firstNameInput.value.trim();
    const lastName = lastNameInput.value.trim();
    const email = emailInput.value.trim();
    const password = passwordInput.value.trim();
    const confirmPassword = confirmPasswordInput.value.trim();
  
    return {
      firstName: firstName,
      lastName : lastName,
      password: password,
      email: email,
      confirmPassword: confirmPassword
    };
  }
  
  function isPasswordSame(pass, confirm) {
    return pass === confirm;
  }
  
  function showFormErrors(formErrors) {
    if (formErrors.length === 0) return;
  
    for (let i = 0; i < formErrors.length; i++) {
      const formError = formErrors[i];
      switch(formError.input) {
        case InputType.password: highlightPasswordError(formError.error);
        break;
        case InputType.email: highlightEmailError(formError.error);
        break;
        case InputType.firstName: highlightFirstNameError(formError.error);
        break;
        case InputType.lastName: highlightLastNameError(formError.error);
        break;
      }
    }
  }
  
  function highlightPasswordError(msg) {
    const elements = document.getElementsByClassName('password-validation');
    elements[0].innerHTML = msg;
    elements[1].innerHTML = msg;
  
    passwordInput.classList.add('is-invalid');
    confirmPasswordInput.classList.add('is-invalid');
  }
  
  function clearErrorHighlights() {
    const elements = document.getElementsByClassName('password-validation');
    elements[0].innerHTML = '';
    elements[1].innerHTML = '';
  
    firstNameValidation.innerHTML = '';
    lastNameValidation.innerHTML = '';
  
    firstNameInput.classList.remove('is-invalid');
    firstNameInput.classList.remove('is-valid');
    lastNameInput.classList.remove('is-valid');
    lastNameInput.classList.remove('is-invalid');
    emailInput.classList.remove('is-valid');
    emailInput.classList.remove('is-invalid')
    passwordInput.classList.remove('is-invalid');
    passwordInput.classList.remove('is-valid');
    confirmPasswordInput.classList.remove('is-invalid');
    confirmPasswordInput.classList.remove('is-valid');
  
    const form = document.getElementById('form');
    form.classList.remove('was-validated');
  }
  
  function enableSpinner(show) {
    const spinner = document.getElementById('spinner');
    spinner.hidden = !show;
    signupButton.disabled = show;
  }

  function highlightFirstNameError(msg) {
    const elm = document.getElementById('firstNameValidation');
    elm.innerHTML = msg;
    firstNameInput.classList.add('is-invalid');
  }

  function highlightLastNameError(msg) {
    const elm = document.getElementById('lastNameValidation');
    elm.innerHTML = msg;
    lastNameInput.classList.add('is-invalid');
  }

  function highlightEmailError(msg) {
    const elm = document.getElementById('emailValidation');
    elm.innerHTML = msg;
    emailInput.classList.add('is-invalid');
  }

  function highLightFormErrors(errors) {
    Object.entries(errors).forEach(entry => {
      
      switch(entry[0].toUpperCase()) {
        case 'PASSWORD': highlightPasswordError(entry[1][0]);
        break;
        case 'FIRSTNAME': highlightFirstNameError(entry[1][0]);
        break;
        case 'LASTNAME': highlightLastNameError(entry[1][0]);
        break;
        case 'EMAIL': highlightEmailError(entry[1][0]);
      }
    });
  }
  
  async function sendSignupRequest(data) {
    try {
      const response = await fetch('https://localhost:7085/api/Auth/Signup', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
      });
  
      const responseData = await response.json();

      if (!response.ok) {
        highLightFormErrors(responseData.errors);
      } else {
        alert('Signup successful');
      }

      enableSpinner(false);
  
    } catch (error) {
      console.error(error);
      enableSpinner(false);
    } finally {
      waitingForRequest = false;
    }
  }
  
  (() => {
      'use strict'
    
      // Fetch all the forms we want to apply custom Bootstrap validation styles to
      const forms = document.querySelectorAll('.needs-validation')
    
      // Loop over them and prevent submission
      Array.from(forms).forEach(form => {
        form.addEventListener('submit', async (event) => {
          clearErrorHighlights();
          event.preventDefault()
  
          if (!form.checkValidity()) {
            event.stopPropagation()
            form.classList.add('was-validated');
          } else {
            const formData = getFormData();
            if (!isPasswordSame(formData.password, formData.confirmPassword)) {
                const formErrors = [{input: InputType.password, error: 'Password does not match'}];
                showFormErrors(formErrors);
                return;
            }
            
            if (!waitingForRequest) {
              waitingForRequest = true;
              enableSpinner(true);
              await sendSignupRequest(formData);
            }
          }
        }, false)
      })
    })();