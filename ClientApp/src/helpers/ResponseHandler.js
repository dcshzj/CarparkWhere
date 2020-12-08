import { authService } from './Authentication';

export function handleResponse(res) {
    return res.text().then(text => {
        const data = text && JSON.parse(text);

        if (!res.ok) {
            if ([401, 403].indexOf(res.status) !== -1) {
                // Logout on 401 Unauthorized or 403 Forbidden
                authService.logout();
            }

            const error = (data && data.message) || res.statusText;
            return Promise.reject(error);
        }

        return data;
    });
}