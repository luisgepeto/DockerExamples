FROM mongo:3.2
COPY ./mongo-scripts/mongo-seed /
COPY ./util /
RUN chmod 777 wait-for-it.sh
CMD ./wait-for-it.sh mongo:27017 -- "mongo admin --host mongo -u admin -p $MONGODB_PASS --eval 'var my_pass = \"$MONGODB_PASSWORD\", my_user = \"$MONGODB_USERNAME\";' db-init.json"