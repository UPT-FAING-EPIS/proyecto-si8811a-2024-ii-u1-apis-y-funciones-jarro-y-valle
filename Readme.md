docker build -t eventos_vj .

docker run -d -p 9091:80 eventos_vj

http://localhost:9091/swagger