function isLoggedIn() {
    const token = localStorage.getItem('token');
    if (token === null || token === '' || token === undefined) {
        return false;
    }
    const currentDate = new Date();
    const tokenExpirationDate = new Date(JSON.parse(localStorage.getItem('token'))['.expires']);
    if (currentDate > tokenExpirationDate) {
        return false;
    }
    return true;
}

function isAdminLoggedIn() {
    const token = localStorage.getItem('token');
    if (token === null || token === '' || token === undefined) {
        return false;
    }
    const currentDate = new Date();
    const tokenExpirationDate = new Date(JSON.parse(localStorage.getItem('token'))['.expires']);
    if (currentDate > tokenExpirationDate) {
        return false;
    }

    if (JSON.parse(localStorage.getItem('token')).role === 'Admin') {
        return true;
    }

    return false;
}

function isDoctorLoggedIn() {
    const token = localStorage.getItem('token');
    if (token === null || token === '' || token === undefined) {
        return false;
    }
    const currentDate = new Date();
    const tokenExpirationDate = new Date(JSON.parse(localStorage.getItem('token'))['.expires']);
    if (currentDate > tokenExpirationDate) {
        return false;
    }

    if (JSON.parse(localStorage.getItem('token')).role === 'Doctor') {
        return true;
    }

    return false;
}