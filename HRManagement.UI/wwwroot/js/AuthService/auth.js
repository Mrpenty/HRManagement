// Function to decode JWT
function parseJwt(token) {
    try {
        return JSON.parse(atob(token.split('.')[1]));
    } catch (e) {
        return null;
    }
}

function handleLogin() {
    // Only attach event if the form exists on the page
    if ($('#loginForm').length) {
        $('#loginForm').on('submit', function (e) {
            e.preventDefault();
            $('#login-error').text('');

            var loginData = {
                email: $('#email').val(),
                password: $('#password').val()
            };

            $.ajax({
                url: 'https://localhost:7201/api/Auth/login',
                type: 'POST',
                contentType: 'application/json',
                data: JSON.stringify(loginData),
                success: function (response) {
                    var d = new Date();
                    d.setTime(d.getTime() + (1 * 24 * 60 * 60 * 1000));
                    var expires = "expires=" + d.toUTCString();
                    document.cookie = "accessToken=" + response.token + ";" + expires + ";path=/";

                    const decodedToken = parseJwt(response.token);
                    if (decodedToken) {
                        const returnUrl = new URLSearchParams(window.location.search).get('ReturnUrl');
                        if (returnUrl) {
                            window.location.href = returnUrl;
                        } else {
                            const role = decodedToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];
                            if (role === 'Employee') {
                                window.location.href = '/Employees/Dashboard';
                            } else {
                                window.location.href = '/';
                            }
                        }
                    } else {
                        $('#login-error').text('Invalid token received. Please check login credentials.');
                    }
                },
                error: function (xhr) {
                    var errorMessage = 'An error occurred.';
                    if (xhr.responseText) {
                        try {
                            var response = JSON.parse(xhr.responseText);
                            errorMessage = response.message || xhr.responseText;
                        } catch (e) {
                            errorMessage = xhr.responseText;
                        }
                    }
                    $('#login-error').text(errorMessage);
                }
            });
        });
    }
}

function handleRegister() {
    // Only attach event if the form exists on the page
    if ($('#registerForm').length) {
        $('#registerForm').on('submit', function (e) {
            e.preventDefault();
            $('#register-error').text('');
            $('#register-success').text('');

            var registerData = {
                firstName: $('#firstName').val(),
                lastName: $('#lastName').val(),
                userName: $('#userName').val(),
                email: $('#email').val(),
                password: $('#password').val()
            };

            $.ajax({
                url: 'https://localhost:7201/api/Auth/register',
                type: 'POST',
                contentType: 'application/json',
                data: JSON.stringify(registerData),
                success: function (response) {
                    $('#register-success').text(response.message || 'Registration successful! Redirecting to login...');
                    setTimeout(function () {
                        window.location.href = '/Auth/Login';
                    }, 2000);
                },
                error: function (xhr) {
                    var errorMessage = 'An error occurred.';
                    if (xhr.responseText) {
                        try {
                            var response = JSON.parse(xhr.responseText);
                            errorMessage = response.message || xhr.responseText;
                        } catch (e) {
                            errorMessage = xhr.responseText;
                        }
                    }
                    $('#register-error').text(errorMessage);
                }
            });
        });
    }
}

// Initialize handlers
$(document).ready(function () {
    handleLogin();
    handleRegister();
}); 