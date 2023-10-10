export interface Settings {
  HelloWorld: string;
}

export let settings: Settings | null = null;

export const setSettings = (settingValues: Settings) => {
  settings = settingValues;
};
