import { handleResponse } from './ResponseHandler';
import { BehaviorSubject } from 'rxjs';

const currentUserSubject = new BehaviorSubject(JSON.parse(localStorage.getItem('currentUser')));

export function authHeader() {
    // Set up the authorisation header with the appropriate JWT token
    const currentUser = authService.currentUserValue;

    if (currentUser && currentUser.token) {
        return { Authorization: `Bearer ${currentUser.token}` };
    } else {
        return {};
    }
}

// Service for handling authentication
export const authService = {
    login,
    logout,
    create,
    currentUser: currentUserSubject.asObservable(),
    get currentUserValue() {
        return currentUserSubject.value;
    }
};

// Service for handling user information
export const userService = {
    getAll
};

function login(email, password) {
    const requestOptions = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ email, password })
    };

    return fetch('/api/users/auth', requestOptions)
        .then(handleResponse)
        .then(user => {
            // Store JWT token in local storage
            localStorage.setItem('currentUser', JSON.stringify(user));
            currentUserSubject.next(user);

            return user;
        });
}

function logout() {
    // Remove JWT token from local storage
    localStorage.removeItem('currentUser');
    currentUserSubject.next(null);
}

function create(email, password, firstname, lastname, contact) {
    const requestOptions = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ email, password, firstname, lastname, contact })
    };

    return fetch('api/users/register', requestOptions)
        .then(handleResponse)
        .then(user => {
            // Immediately get the user to log in
            window.location.assign('/login');
        });
}

function getAll() {
    const requestOptions = { method: 'GET', headers: authHeader() };
    return fetch('api/users', requestOptions).then(handleResponse);
}
