FROM node:24-alpine

WORKDIR /home/app

COPY home-finances-frontend/src/. ./src
COPY home-finances-frontend/eslint.config.js ./
COPY home-finances-frontend/index.html ./
COPY home-finances-frontend/package.json ./
COPY home-finances-frontend/tsconfig.app.json ./
COPY home-finances-frontend/tsconfig.json ./
COPY home-finances-frontend/tsconfig.node.json ./
COPY home-finances-frontend/vite.config.ts ./

RUN npm install

EXPOSE 4000

ENTRYPOINT [ "npm", "run", "dev", "--", "--host" ]
