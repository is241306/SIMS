window.auth = {
    save: function (token, username, role) {
        localStorage.setItem('authToken', token);
        localStorage.setItem('authUsername', username);
        localStorage.setItem('authRole', role);
    },
    getToken: function () {
        return localStorage.getItem('authToken');
    },
    getUsername: function () {
        return localStorage.getItem('authUsername');
    },
    getRole: function () {
        return localStorage.getItem('authRole');
    },
    clear: function () {
        localStorage.removeItem('authToken');
        localStorage.removeItem('authUsername');
        localStorage.removeItem('authRole');
    }
};
