# Core Functionalities
## Photo CRUD
- Photo metadata
- - Title
- - FileSourceName
- - Album
- - Location
- - DateTaken
- - CreatedOn
- - CreatedBy
- - Tags
- - OwnedBy?
- Photos can be queried with search functionality
- Each photo can be read
- - In preview mode (reduced quality, with details)
- - In source mode (full quality, without details)
- - In presentation mode (preview mode, preview mode with ability to quickly move between photos)
## Photo Management
- Photos are stored in albums (logical management)
- Album metadata
- - Name
- - CreatedOn
- - CreatedBy
- - Description
- - IsSystemAlbum?
- - OwnedBy?
- Each album can be either private or public
## Location
- Each photo can be assigned to certain location
- Locations CRUD
- Location metadata
- - Name
- - Type (Country, City, Geographical Area etc.)
- - IsPublic
- - Latitude
- - Longitude
- - CreatedOn
- - CreatedBy
- - Description
- Locations follow hierarchy pattern - each can compose other locations
- Each user should have access to interactive map
## Account
- Account metadata:
- - Email
- - AccountName
- - UserName
- - UserSurname
- - RegisteredOn
- - LastSeenOn
## Photo Sharing
# Key Concepts
- App comes with one system user named uPhoto
- Locations can be public or private
- - Public locations are created by system user