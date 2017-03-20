FROM mongo:3.2
COPY ./mongo-scripts/mongo-seed /
COPY ./util /
ENV MY_PASS=pass \
    MY_USER=user
RUN chmod 777 wait-for-it.sh
CMD ./wait-for-it.sh mongo:27017 -- "mongo admin --host mongo -u admin -p password --eval 'var my_pass = \"$MY_PASS\", my_user = \"$MY_USER\";' db-init.json"