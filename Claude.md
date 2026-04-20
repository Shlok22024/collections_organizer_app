# Collectify – Static Website Prototype (AI Developer Instruction File)

## Objective
Build a fully functional static website prototype using HTML, CSS (Bootstrap 5), and JavaScript. The website must simulate a collection tracking application with CRUD navigation and data visualization using Chart.js. The idea is to have a single web-app to keep track of all your separate collections (eg. TCG, Figurines, Merch, Coins, Notes, etc.)

This is a frontend-only implementation. No backend, database, or real API integration is required.

The website name is still under consideration.
---

## Tech Stack Requirements
- HTML5
- CSS3
- Bootstrap 5 (CDN)
- React + Vanilla JavaScript
- Chart.js (CDN)
- Botpress Webchat (to be integrated last)

---

## Folder Structure


/collectify
├── index.html
├── dashboard.html
├── create.html
├── read.html
├── update.html
├── delete.html
├── about.html
├── /css
│ └── styles.css
├── /js
│ └── charts.js
└── /assets
└── ldm.png


---

## Global UI Requirements

### Navbar (REQUIRED ON ALL PAGES)
- Left: App name "Collectify"
- Links:
  - Home → index.html
  - Dashboard → dashboard.html
  - CRUD (Dropdown)
    - Create → create.html
    - Read → read.html
    - Update → update.html
    - Delete → delete.html
  - About → about.html
  - Profile (if logged in, else a signup/login option)
    - Profile.html - if user is logged in
    - Login.html - Signup/login page if not logged in

## Smooth Scrolling Instruction
Add smooth scrolling behavior for anchor based navigation on the Home page.

### Requirement
- When a user clicks any navbar link or button that points to a section on the same page, the scroll should animate smoothly instead of jumping instantly.
  - Do not add any heavy animation library for this.
  - Keep the effect subtle and modern.
  - Ensure this does not break responsiveness or navigation.

### Styling Rules
- Use Bootstrap grid system
- Use cards for content blocks
- Apply consistent spacing (margin/padding)
- Use one primary accent color
- Buttons must be consistent across pages
- Layout must be responsive (desktop + mobile)

### Asset instructions
- Get images for items and icons online. Use relevant images to the respective texts
- Generate a temporary logo for the site
---

## Page Specifications

---

## 1. Home Page (`index.html`)

### Sections

#### Hero Section
- Title: "Collectify"
- Subtitle: "Track and manage all your collections in one place"
- CTA Button → links to dashboard.html

#### Features Section (3 cards)
- Multi-Collection Tracking
- Portfolio Value Insights
- Category-Based Organization

#### Preview Section
- Display 3 dummy cards:
  - Total Collections
  - Total Items
  - Estimated Portfolio Value

---

## 2. Dashboard Page (`dashboard.html`)

### Layout
- Use Bootstrap grid
- Each chart inside a card container

### Chart 1: Pie Chart
- Title: "Portfolio Distribution by Category"
- Labels: Cards, Vinyl, Figurines
- Dummy Data: [40, 35, 25]

### Chart 2: Bar Chart
- Title: "Top Valuable Items"
- X-axis: Item names (e.g., Pikachu Card, Rare Vinyl, Anime Figure)
- Y-axis: Value
- Dummy Data: realistic values (e.g., 120, 300, 220)

### Chart 3: Line Chart
- Title: "Portfolio Value Over Time"
- X-axis: Months (Jan–Jun)
- Y-axis: Total value
- Dummy Data: increasing trend

### Requirements
- Use Chart.js
- Enable tooltips
- Add axis labels
- Charts must render correctly on page load

---

## 3. Create Page (`create.html`)

### Form Fields
- Item Name (text input)
- Category (dropdown)
  - Cards
  - Vinyl
  - Figurines
- Purchase Price (number input)
- Estimated Value (number input)

### Button
- "Create Item" (no functionality required)

### Layout
- Centered form inside card
- Proper spacing and labels

---

## 4. Read Page (`read.html`)

### Table
Columns:
- Item Name
- Category
- Purchase Price
- Estimated Value

### Data
- Populate with 5–7 dummy rows

### Optional UI
- Search bar (non-functional)

---

## 5. Update Page (`update.html`)

### Form
Same as Create Page, but:
- Fields must be pre-filled with dummy data

### Button
- "Update Item" (no functionality required)

---

## 6. Delete Page (`delete.html`)

### Table/List
- Same structure as Read page

### Additional Column
- "Delete" button per row

### Optional Enhancement
- Add confirmation modal (Bootstrap)

---

## 7. About Page (`about.html`)

### Sections

#### Team Info
- Name
- Role: Developer
- Contribution: UI Design and Implementation

#### Logical Data Model
- Display image: `/assets/ldm.png`

### Data Model Description (Text below image)
- User → Collections (1:M)
- Collection → Items (1:M)
- Item → PriceHistory (1:M) [optional]

## 8. Profile Page (Profile.html)
Only shown when user is logged in
- Profile photo
- Total portfolio value
- Collections
- Settings
- Logout button

## 9. Login.html
Same window hosts a signup form and has a button to switch to login form if
Follow standard industry practices for such forms
Once succesfully signed up/logged in, send to dashboard.html

### Signup form
- Name - First and Last Name
- Email
- Password
- Social sign in options - Google, Microsoft, Apple

### Login form
- Email
- Password
- Forgot Password (a static button for now)
- Social sign in options - Google, Microsoft, Apple

---

## Logical Data Model Requirements

### Entities
- User
- Collection
- Item
- PriceHistory (optional)

### Relationships
- One-to-Many:
  - User → Collections
  - Collection → Items
  - Item → PriceHistory

### Must include:
- Primary Keys
- Foreign Keys

---

## JavaScript Requirements

### charts.js
- Initialize all 3 charts
- Use static dummy data
- Ensure charts load only on dashboard page

---

## CSS Requirements (`styles.css`)
- Customize Bootstrap minimally
- Add:
  - Card shadow
  - Border radius
  - Spacing improvements
- Maintain clean, modern look

---

## Navigation Requirements
- All links must work
- No broken routes
- Navbar must be identical across pages

---

## Responsiveness
- Use Bootstrap grid
- Test:
  - Desktop
  - Tablet
  - Mobile

---

## Botpress Integration (FINAL STEP - INCLUDE ONLY AFTER USER INSTRUCTION)
- Add Botpress script to all pages
- Chatbot should load on bottom right
- No advanced configuration required

---

## Non-Functional Constraints
- No backend
- No database
- No API calls
- No real authentication
- No real CRUD operations

---

## Completion Criteria
- All pages render correctly
- Navigation works across all pages
- 3 charts display properly
- Forms and tables are present
- UI is consistent and responsive
- LDM image is included

---