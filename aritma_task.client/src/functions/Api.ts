import axios, { AxiosError, AxiosResponse } from 'axios';

export interface ApiResponse<T> {
    data: T;
    status: number;
    statusText: string;
}

const baseUrl = "https://localhost:7129/api";

const Api = async <T>(
    method: 'GET' | 'POST' | 'PUT' | 'DELETE',
    endpoint: string,
    data?: any
): Promise<T> => {
    try {
        const response: AxiosResponse<T> = await axios({
            method,
            url: baseUrl + endpoint,
            data,
        });

        if (typeof response.data !== 'undefined') {
            return response.data;
        } else {
            throw new Error('Unexpected response data type');
        }
    } catch (error) {
        const axiosError = error as AxiosError;

        if (axiosError.isAxiosError) {
            console.error('API request error:', axiosError.response?.data);
            throw new Error(axiosError.message || 'API request failed');
        } else {
            console.error('Unknown error:', error);
            throw error;
        }
    }
};

export default Api;