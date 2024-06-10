export default {
    preset: 'ts-jest',
    testEnvironment: "jsdom",
    setupFilesAfterEnv: ["<rootDir>/src/jest.setup.ts"],
    moduleFileExtensions: ['ts', 'tsx', 'js', 'jsx', 'json', 'node'],
};