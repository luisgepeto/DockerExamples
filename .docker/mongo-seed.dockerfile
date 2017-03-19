FROM mongo:3.2
#this paths seem to be relative to where the build is happening
COPY .docker/mongo-scripts/mongo-seed /
ENV MY_PASS=pass \
    MY_USER=user
CMD mongo admin --host mongo -u admin -p password --eval "var my_pass = '$MY_PASS', my_user = '$MY_USER';" db-init.json