import Settings from '../Settings';

class PetDeskApiService {
  static apiUrl = null;
  static Appointments = require('./petdesk_api/appointments');

  static request = async (method, uri, body) => {
    const headers = {
      'Content-Type': 'application/json',
      Authorization: `Bearer ${this.token}`,
    };

    const options = {
      headers: headers,
      body: method === 'GET' ? null : JSON.stringify(body),
      method: method,
    };

    const url = `${this.apiUrl}${uri}`;
    const response = await fetch(url, options);
    return await response.json();
  };

  static setApiUrl() {
    this.apiUrl = Settings.getApiUrl();
  }
}

export default PetDeskApiService;
