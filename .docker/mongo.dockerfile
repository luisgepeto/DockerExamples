FROM mongo:3.4
MAINTAINER Luis Becerril
RUN touch /var/log/mongod.log
RUN ["mongod", "--auth", "--fork", "--logpath", "/var/log/mongod.log"]
RUN rm /tmp/mongodb-27017.sock
RUN echo "hello world"