# LogProxyApi

Create a Log Proxy API, which receives log messages and forwards them to third-party API.

Requirements:

⁃ Use .Net Core 3.1 Web Api

⁃ Implement basic authentication to your methods

⁃ Implement POST /messages, which receives simple JSON object in Body with two attributes "title" and “text" and transfers them to third-party API (see description below) to
fields Summary and Message enriching record with generated id and current timestamp

⁃ Implement GET /messages which returns all the messages from the third-party API

Response example should be

[
 {
 "id": "1",
 “title”: "Test message summary",
 “Text”: "Exceptiion occured at ...",
 "receivedAt": "2021-01-01T00:38:00.000Z"
 },
 {
 "id": "1",
 “Title”: "Test message summary",
 “Text”: "Exceptiion occured at ...",
 "receivedAt": "2021-01-01T00:38:00.000Z"
 }
 ]
 
⁃ Implement tests, which you think are needed for this API

⁃ Upload code to your favourite source control system provider (gtihub, gitlab, etc.)

⁃ It would be nice if you will pack this app to the docker container

⁃ Send us link to your source code repository together with instructions how to build and

Third-party API to be used:

It is a simple API for AirTable database.

Examples:

List all messages

EXAMPLE REQUEST

curl
"https://api.airtable.com/v0/appD1b1YjWoXkUJwR/Messages?maxRecords=3&view=Grid%20vi
ew" \
 -H "Authorization: Bearer YOUR_API_KEY"
EXAMPLE RESPONSE
{
 "records": [
 {
 "id": "recCR2LP7wZVioc5H",
 "fields": {
 "id": "1",
 "Summary": "Test message summary",
 "Message": "Exceptiion occured at ...",
 "receivedAt": "2021-01-01T00:38:00.000Z"
 },
 "createdTime": "2021-01-13T23:37:41.000Z"
 },
 {
 "id": "recQ0hqD2PhSmJpft",
 "fields": {},
 "createdTime": "2021-01-13T23:38:37.000Z"
 }
 ],
 "offset": "recQ0hqD2PhSmJpft"
}

Create Message:

EXAMPLE REQUEST
curl -v -X POST https://api.airtable.com/v0/appD1b1YjWoXkUJwR/Messages \
 -H "Authorization: Bearer YOUR_API_KEY" \
 -H "Content-Type: application/json" \
 --data '{
 "records": [
 {
 "fields": {
 "id": "1",
 "Summary": "Test message summary",
 "Message": "Exceptiion occured at ...",
 "receivedAt": "2021-01-01T00:38:00.000Z"
 }
 },
 {
 "fields": {
 "id": "1",
 "Summary": "Test message summary",
 "Message": "Exceptiion occured at ...",
 "receivedAt": "2021-01-01T00:38:00.000Z"
 }
 }
 ]
}'

EXAMPLE RESPONSE
{
 "records": [
 {
 "id": "recCR2LP7wZVioc5H",
 "fields": {
 "id": "1",
 "Summary": "Test message summary",
 "Message": "Exceptiion occured at ...",
 "receivedAt": "2021-01-01T00:38:00.000Z"
 },
 "createdTime": "2021-01-13T23:37:41.000Z"
 },
 {
 "id": "recCR2LP7wZVioc5H",
 "fields": {
 "id": "1",
 "Summary": "Test message summary",
 "Message": "Exceptiion occured at ...",
 "receivedAt": "2021-01-01T00:38:00.000Z"
 },
 "createdTime": "2021-01-13T23:37:41.000Z"
 }
 ]
}
API_KEY: ******
