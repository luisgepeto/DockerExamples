FROM mongo:3.2
COPY ./mongo-scripts/mongo-seed/ /
ENV MY_PASS=user \
    MY_USER=pass
#CMD ["wait-for-it.sh", "mongo:27017"]
CMD mongo admin --host mongo -u admin -p password --eval "var my_pass = '$MY_PASS', my_user = '$MY_USER';" db-init.json
CMD mongo admin --host mongo -u admin -p password data-init.json
