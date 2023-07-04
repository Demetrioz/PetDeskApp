class Settings {
  static getApiUrl() {
    const urlMap = {
      localhost: 'https://localhost:44358/',
    };

    return urlMap[window.location.hostname];
  }
}

export default Settings;
