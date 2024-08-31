docker build -t mi-proyecto-api .

docker run -d -p 8080:80 mi-proyecto-api

http://localhost:8080/swagger