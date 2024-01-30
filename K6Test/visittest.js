import http from 'k6/http';
import { check, sleep } from 'k6';

export const options = {
    stages: [
        { duration: '30s', target: 20 },
        { duration: '10s', target: 10 },
        { duration: '20s', target: 0 },
        { duration: '20s', target: 100 },
        { duration: '20s', target: 500 },
        { duration: '20s', target: 1000 },
        { duration: '20s', target: 10000 },
    ],
};

export default function () {
    const res = http.get('http://localhost:5092/');
    sleep(1);
}