/** @type {import('next').NextConfig} */
const nextConfig = {
    async headers() {
        return [
            {
                // matching all API routes
                source: "/api/:path*",
                headers: [
                    { key: "Access-Control-Allow-Credentials", value: "true" },
                    { key: "Access-Control-Allow-Origin", value: "http://localhost:3000" },
                    { key: "Access-Control-Allow-Methods", value: "GET,DELETE,PATCH,POST,PUT" },
                    { key: "Access-Control-Allow-Headers", value: "X-CSRF-Token, X-Requested-With, Accept, Accept-Version, Content-Length, Content-MD5, Content-Type, Date, X-Api-Version" },
                ]
            }
        ]
    }
}

module.exports = {
    async headers() {
        return [
            {
                source: '/api/:path*',
                headers: [
                    {
                        key: 'Access-Control-Allow-Origin',
                        value: 'http://localhost:3000',
                    },
                ],
            },
        ];
    },
    env: {
        NEXTAUTH_URL: "http://localhost:3000",
        NEXTAUTH_SECRET: "j/9bfoyBXvgqdO/zi/nRfUlr8VDuyPI5B0DgPCa4Nws=",

        GOOGLE_CLIENT_ID: "230619720980-d0iklanmnfpgrt2jee5mj7hndv9md8f2.apps.googleusercontent.com",
        GOOGLE_CLIENT_SECRET: "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",

    }
};
