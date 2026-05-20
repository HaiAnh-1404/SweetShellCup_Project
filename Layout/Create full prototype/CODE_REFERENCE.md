# 📁 Code Reference - Sweet Shell Cup Prototype

## 🗂️ File Structure

```
/workspaces/default/code/
│
├── README.md                    # Quick start guide
├── NAVIGATION_GUIDE.md          # How to navigate
├── PROTOTYPE_INFO.md            # Technical details
├── CODE_REFERENCE.md            # This file
│
├── package.json                 # Dependencies
│
└── src/
    ├── app/
    │   ├── App.tsx             # Main app entry (RouterProvider)
    │   ├── routes.tsx          # Route configuration
    │   │
    │   └── pages/              # Page wrapper components
    │       ├── HomePage.tsx
    │       ├── OurStoryPage.tsx
    │       ├── ShopPage.tsx
    │       ├── CartPage.tsx
    │       ├── FeedbackPage.tsx
    │       └── DetailPage.tsx
    │
    ├── imports/                # Figma imported components
    │   ├── CuisineIceCreamIceCreamShopPrestashopFigmaTemplate/
    │   ├── Menu/
    │   ├── Product/
    │   ├── OurStory/
    │   ├── Feedback/
    │   ├── Cart/
    │   ├── GioHang/
    │   └── Detail/
    │
    └── styles/                 # CSS files
        ├── fonts.css
        └── theme.css
```

---

## 🔗 Route Configuration

**File:** `/workspaces/default/code/src/app/routes.tsx`

```typescript
{
  path: "/",              Component: HomePage
  path: "/our-story",     Component: OurStoryPage
  path: "/shop",          Component: ShopPage
  path: "/cart",          Component: CartPage
  path: "/feedback",      Component: FeedbackPage
  path: "/detail/:id",    Component: DetailPage
}
```

---

## 📄 Main Files

### 1. App.tsx
**Path:** `/workspaces/default/code/src/app/App.tsx`

```tsx
import { RouterProvider } from 'react-router';
import { router } from './routes';

export default function App() {
  return <RouterProvider router={router} />;
}
```

**Purpose:** Entry point của ứng dụng, setup RouterProvider

---

### 2. routes.tsx
**Path:** `/workspaces/default/code/src/app/routes.tsx`

**Purpose:** Định nghĩa tất cả các routes và mapping với components

**Routes:**
- `/` → HomePage
- `/our-story` → OurStoryPage
- `/shop` → ShopPage
- `/cart` → CartPage
- `/feedback` → FeedbackPage
- `/detail/:id` → DetailPage

---

### 3. Page Components

#### HomePage.tsx
**Path:** `/workspaces/default/code/src/app/pages/HomePage.tsx`
- Import: `CuisineIceCreamIceCreamShopPrestashopFigmaTemplate`
- Handle navigation clicks

#### OurStoryPage.tsx
**Path:** `/workspaces/default/code/src/app/pages/OurStoryPage.tsx`
- Import: `OurStory`
- Handle navigation clicks

#### ShopPage.tsx
**Path:** `/workspaces/default/code/src/app/pages/ShopPage.tsx`
- Import: `Product`
- Handle navigation clicks
- Handle product click → navigate to detail

#### CartPage.tsx
**Path:** `/workspaces/default/code/src/app/pages/CartPage.tsx`
- Import: `Cart`
- Handle navigation clicks

#### FeedbackPage.tsx
**Path:** `/workspaces/default/code/src/app/pages/FeedbackPage.tsx`
- Import: `Feedback`
- Handle navigation clicks

#### DetailPage.tsx
**Path:** `/workspaces/default/code/src/app/pages/DetailPage.tsx`
- Import: `Detail`
- Handle "Back" button click → navigate to /shop

---

## 🎨 Imported Figma Components

### 1. CuisineIceCreamIceCreamShopPrestashopFigmaTemplate
**Path:** `/workspaces/default/code/src/imports/CuisineIceCreamIceCreamShopPrestashopFigmaTemplate/CuisineIceCreamIceCreamShopPrestashopFigmaTemplate.tsx`
- **Used in:** HomePage
- **Content:** Main landing page with hero banner

### 2. OurStory
**Path:** `/workspaces/default/code/src/imports/OurStory/OurStory.tsx`
- **Used in:** OurStoryPage
- **Content:** Brand story, vision, mission, values

### 3. Product
**Path:** `/workspaces/default/code/src/imports/Product/Product.tsx`
- **Used in:** ShopPage
- **Content:** Product grid with ice cream items

### 4. Cart
**Path:** `/workspaces/default/code/src/imports/Cart/Cart.tsx`
- **Used in:** CartPage
- **Content:** Shopping cart with product table

### 5. Feedback
**Path:** `/workspaces/default/code/src/imports/Feedback/Feedback.tsx`
- **Used in:** FeedbackPage
- **Content:** Customer testimonials and reviews

### 6. Detail
**Path:** `/workspaces/default/code/src/imports/Detail/Detail.tsx`
- **Used in:** DetailPage
- **Content:** Product detail page with description

---

## 🔧 Navigation Logic

Mỗi page component có navigation handler:

```tsx
const handleNavigation = (e: React.MouseEvent) => {
  const target = e.target as HTMLElement;
  const text = target.textContent?.trim().toLowerCase();

  if (text === "home") navigate("/");
  else if (text === "our story") navigate("/our-story");
  else if (text === "shop") navigate("/shop");
  else if (text === "cart") navigate("/cart");
  else if (text === "feedback") navigate("/feedback");
};
```

**Special cases:**
- ShopPage: Click sản phẩm → `/detail/1`
- DetailPage: Click "Back" → `/shop`

---

## 📦 Dependencies

**File:** `/workspaces/default/code/package.json`

Key dependencies:
- `react`: 18.3.1
- `react-router`: 7.13.0
- `tailwindcss`: 4.1.12
- `vite`: 6.3.5

---

## 🚀 How It Works

1. **App.tsx** creates RouterProvider with router config
2. **routes.tsx** defines all routes and components
3. **Page components** wrap Figma imports and add navigation
4. **Click handlers** detect menu clicks and navigate
5. **React Router** handles URL changes without page reload

---

## 💻 Code Locations Summary

| Component | Path |
|-----------|------|
| Main App | `/workspaces/default/code/src/app/App.tsx` |
| Routes | `/workspaces/default/code/src/app/routes.tsx` |
| Pages | `/workspaces/default/code/src/app/pages/` |
| Imports | `/workspaces/default/code/src/imports/` |
| Styles | `/workspaces/default/code/src/styles/` |

---

**All code is ready and fully functional!** ✨
