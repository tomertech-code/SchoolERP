function toggleVisibility(elementId) {
    const element = document.getElementById(elementId);
    if (element.style.display === "none" || element.style.display === "") {
        element.style.display = "block";
    } else {
        element.style.display = "none";
    }
}

function validateRequiredFields(formId) {
    const form = document.getElementById(formId);
    const requiredFields = form.querySelectorAll("[required]");
    let isValid = true;

    requiredFields.forEach(field => {
        if (!field.value.trim()) {
            isValid = false;
            field.style.borderColor = "red";  // Optional: Highlight invalid field
            showAlert("Please fill out all required fields", 'error');
        } else {
            field.style.borderColor = "";  // Reset border color if valid
        }
    });

    return isValid;
}

function formatDate(date) {
    const d = new Date(date);
    const day = d.getDate().toString().padStart(2, '0');
    const month = (d.getMonth() + 1).toString().padStart(2, '0');
    const year = d.getFullYear();
    return `${day}/${month}/${year}`;
}

function fetchData(url, successCallback, errorCallback) {
    fetch(url)
        .then(response => response.json())
        .then(data => successCallback(data))
        .catch(error => {
            console.error('Error fetching data:', error);
            if (errorCallback) errorCallback(error);
        });
}

function debounce(func, wait) {
    let timeout;
    return function () {
        const context = this;
        const args = arguments;
        clearTimeout(timeout);
        timeout = setTimeout(() => func.apply(context, args), wait);
    };
}

function jsonToTable(jsonData) {
    const table = document.createElement("table");
    const headers = Object.keys(jsonData[0]);

    // Create the table header row
    const headerRow = table.insertRow();
    headers.forEach(header => {
        const th = document.createElement("th");
        th.textContent = header;
        headerRow.appendChild(th);
    });

    // Create table rows
    jsonData.forEach(rowData => {
        const row = table.insertRow();
        headers.forEach(header => {
            const cell = row.insertCell();
            cell.textContent = rowData[header];
        });
    });

    return table;
}

function toggleLoadingSpinner(show) {
    const spinner = document.getElementById('loadingSpinner');
    if (show) {
        spinner.style.display = 'block';
    } else {
        spinner.style.display = 'none';
    }
}
<div id="loadingSpinner" style="display:none;">Loading...</div>

function clearChildren(elementId) {
    const element = document.getElementById(elementId);
    while (element.firstChild) {
        element.removeChild(element.firstChild);
    }
}

function showAlert(message, type = 'success') {
    const alertBox = document.createElement('div');
    alertBox.classList.add('alert', `alert-${type}`);
    alertBox.textContent = message;

    document.body.appendChild(alertBox);

    setTimeout(() => {
        alertBox.remove();
    }, 3000);
}


function setCookie(name, value, days) {
    const date = new Date();
    date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000)); // Set expiry date
    const expires = "expires=" + date.toUTCString();
    document.cookie = `${name}=${value}; ${expires}; path=/`;
}


function getCookie(name) {
    const nameEq = name + "=";
    const cookies = document.cookie.split(';');
    for (let i = 0; i < cookies.length; i++) {
        let c = cookies[i].trim();
        if (c.indexOf(nameEq) === 0) return c.substring(nameEq.length, c.length);
    }
    return "";
}


function redirectAfterDelay(url, delay) {
    setTimeout(() => {
        window.location.href = url;
    }, delay);
}


function preventEnterSubmit(formId) {
    const form = document.getElementById(formId);
    form.addEventListener('keydown', function (event) {
        if (event.key === 'Enter') {
            event.preventDefault();
        }
    });
}


function clearLocalStorage() {
    localStorage.clear();
}


function generateRandomString(length) {
    const characters = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
    let result = '';
    for (let i = 0; i < length; i++) {
        result += characters.charAt(Math.floor(Math.random() * characters.length));
    }
    return result;
}


function scrollToTop() {
    window.scrollTo({ top: 0, behavior: 'smooth' });
}

//Format Date as DD / MM / YYYY
function formatDateDDMMYYYY(date) {
    const d = new Date(date);
    const day = d.getDate().toString().padStart(2, '0');
    const month = (d.getMonth() + 1).toString().padStart(2, '0');
    const year = d.getFullYear();
    return `${day}/${month}/${year}`;
}

//Format Date as MM / DD / YYYY
function formatDateMMDDYYYY(date) {
    const d = new Date(date);
    const month = (d.getMonth() + 1).toString().padStart(2, '0');
    const day = d.getDate().toString().padStart(2, '0');
    const year = d.getFullYear();
    return `${month}/${day}/${year}`;
}


//Format Date as YYYY - MM - DD
function formatDateYYYYMMDD(date) {
    const d = new Date(date);
    const year = d.getFullYear();
    const month = (d.getMonth() + 1).toString().padStart(2, '0');
    const day = d.getDate().toString().padStart(2, '0');
    return `${year}-${month}-${day}`;
}

//. Format Date as YYYY - MM - DD HH: mm: ss
function formatDateWithTime(date) {
    const d = new Date(date);
    const year = d.getFullYear();
    const month = (d.getMonth() + 1).toString().padStart(2, '0');
    const day = d.getDate().toString().padStart(2, '0');
    const hours = d.getHours().toString().padStart(2, '0');
    const minutes = d.getMinutes().toString().padStart(2, '0');
    const seconds = d.getSeconds().toString().padStart(2, '0');
    return `${year}-${month}-${day} ${hours}:${minutes}:${seconds}`;
}

//Format Date as DD - MMM - YYYY(e.g., 01 - Jan - 2022
function formatDateDDMMMYYYY(date) {
    const d = new Date(date);
    const day = d.getDate().toString().padStart(2, '0');
    const monthNames = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"];
    const month = monthNames[d.getMonth()];
    const year = d.getFullYear();
    return `${day}-${month}-${year}`;
}


//Get Time Difference(e.g., 2 days ago, 1 hour ago)
function timeAgo(date) {
    const now = new Date();
    const diffInMs = now - new Date(date);
    const seconds = Math.floor(diffInMs / 1000);
    const minutes = Math.floor(seconds / 60);
    const hours = Math.floor(minutes / 60);
    const days = Math.floor(hours / 24);
    const months = Math.floor(days / 30);
    const years = Math.floor(months / 12);

    if (years > 0) {
        return `${years} year${years > 1 ? 's' : ''} ago`;
    } else if (months > 0) {
        return `${months} month${months > 1 ? 's' : ''} ago`;
    } else if (days > 0) {
        return `${days} day${days > 1 ? 's' : ''} ago`;
    } else if (hours > 0) {
        return `${hours} hour${hours > 1 ? 's' : ''} ago`;
    } else if (minutes > 0) {
        return `${minutes} minute${minutes > 1 ? 's' : ''} ago`;
    } else {
        return `${seconds} second${seconds > 1 ? 's' : ''} ago`;
    }
}

//Get Day of the Week(e.g., Monday, Tuesday)
function getDayOfWeek(date) {
    const daysOfWeek = ["Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"];
    const d = new Date(date);
    return daysOfWeek[d.getDay()];
}


//Generate Random Number
function getRandomNumber(min, max) {
    return Math.floor(Math.random() * (max - min + 1)) + min;
}
