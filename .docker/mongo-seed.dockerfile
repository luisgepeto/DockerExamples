FROM mongo:3.2
COPY ./mongo-scripts/mongo-seed/ /
CMD mongo admin --host mongo -u admin -p password 
# < db-init.json
#CMD mongoimport --host mongo --db test --collection Products --type json --file /init.json --jsonArray