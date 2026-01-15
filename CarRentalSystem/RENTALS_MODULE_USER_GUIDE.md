# Rentals Module - User Guide

## ?? Table of Contents
1. [Introduction](#introduction)
2. [Accessing the Rentals Module](#accessing-the-rentals-module)
3. [Viewing Rentals](#viewing-rentals)
4. [Creating a New Rental](#creating-a-new-rental)
5. [Viewing Rental Details](#viewing-rental-details)
6. [Editing a Rental](#editing-a-rental)
7. [Returning a Vehicle](#returning-a-vehicle)
8. [Cancelling a Rental](#cancelling-a-rental)
9. [Deleting a Rental](#deleting-a-rental)
10. [Understanding Rental Statuses](#understanding-rental-statuses)
11. [Tips & Best Practices](#tips--best-practices)
12. [Common Scenarios](#common-scenarios)
13. [Troubleshooting](#troubleshooting)

---

## Introduction

The **Rentals Module** is the heart of the Car Rental System. It allows you to manage all vehicle rental transactions from start to finish. This module handles:

- Creating new rental reservations
- Managing active rentals
- Processing vehicle returns
- Handling cancellations
- Tracking payments and financial status
- Maintaining complete rental history

---

## Accessing the Rentals Module

### Navigation
1. Click on the **"Rentals"** link in the main navigation menu
2. You can also access rentals from:
   - Client details page (view client's rental history)
   - Vehicle details page (view vehicle's rental history)
   - Dashboard (quick stats and links)

---

## Viewing Rentals

### Main Rentals List

When you open the Rentals module, you'll see:

#### ?? Statistics Dashboard
At the top of the page, four colored cards show:
- **Reserved** (Blue): Number of reservations waiting for pickup
- **Active** (Yellow): Number of rentals currently in progress
- **Completed** (Green): Number of successfully completed rentals
- **Overdue** (Red): Number of rentals past their return date

#### ?? Search & Filter Panel
Use the filters to find specific rentals:

**Status Filter:**
- Select from: All Statuses, Reserved, Active, Completed, Cancelled, Overdue
- Instantly filters the list to show only rentals with that status

**Date Filters:**
- **From Date:** Show rentals starting from this date
- **To Date:** Show rentals up to this date
- Use both for a specific date range

**Action Buttons:**
- **Search:** Apply the selected filters
- **Reset:** Clear all filters and show all rentals

#### ?? Rentals Table
The table displays:
- **ID:** Unique rental identifier
- **Client:** Customer name (click to view client profile)
- **Vehicle:** Car details with registration number
- **Employee:** Staff member handling the rental
- **Rental Date:** When the rental started
- **Return Date:** When the car should be/was returned
- **Duration:** Number of days
- **Daily Rate:** Cost per day
- **Total Cost:** Complete rental cost
- **Status:** Current rental status with color coding
- **Actions:** Quick buttons to view details or edit

**Color Coding:**
- Overdue rentals appear in red (danger color)
- All statuses use color-coded badges for easy identification

---

## Creating a New Rental

### Step-by-Step Process

#### 1. Start Creating
- Click the **"New Rental"** button (green button at the top)
- You'll see a comprehensive form with 5 sections

#### 2. Section 1: Client Information
**Select Client:**
- Click the dropdown to see all clients
- Format: "FirstName LastName (email@example.com)"
- Sorted alphabetically by last name
- **New Client?** Click "Add New Client" button to open client creation form

#### 3. Section 2: Vehicle Selection
**Select Vehicle:**
- Only **available** vehicles are shown
- Format: "Brand Model (Registration) - $XX.XX/day"
- Sorted by brand, then model
- **Daily Price Display:** Once selected, the daily rate appears in a blue info box

#### 4. Section 3: Employee Information
**Assign Employee:**
- Select the staff member handling this rental
- Format: "FirstName LastName - Position"
- Choose the employee who will be responsible

#### 5. Section 4: Rental Period
**Rental Start Date:**
- Select when the customer will pick up the vehicle
- Minimum: Today's date
- Default: Today

**Expected Return Date:**
- Select when the customer should return the vehicle
- Must be **after** the rental start date
- System validates this automatically

**Real-Time Calculation:**
- As soon as you select both dates, the system shows:
  - **Rental Duration:** Number of days
  - **Estimated Total:** Automatic calculation (daily rate ? days)

#### 6. Section 5: Initial Status
**Choose Status:**
- **Reserved:** Customer has booked but not yet picked up
  - Use this for future reservations
  - Vehicle status becomes "Reserved"
- **Active:** Customer is picking up right now
  - Use this for immediate rentals
  - Vehicle status becomes "Rented"

#### 7. Submit
- Click **"Create Rental"** (green button)
- System performs these checks:
  - ? Vehicle is available
  - ? Return date is after rental date
  - ? No overlapping rentals for this vehicle
- If all checks pass:
  - Rental is created
  - Vehicle status is updated
  - You're redirected to rental details page

### ?? Important Notes
- **Vehicle Availability:** System prevents double-booking
- **Date Validation:** Return date must be after rental date
- **Overlapping Check:** Cannot book a car that's already rented for those dates

---

## Viewing Rental Details

### What You'll See

#### Rental Overview Card (Blue)
**Rental Period:**
- Start Date (with full month name)
- Return Date (or "Not returned yet")
- Duration in days

**Financial Summary:**
- Daily Rate
- Total Cost (daily rate ? days)
- Total Paid (sum of completed payments)
- Remaining Balance (red if unpaid, green if paid)

**Current Status:**
- Large status badge with icon
- Description of what the status means

#### Client Information Card (Blue/Cyan)
- Full name
- Email (clickable to send email)
- Phone number (clickable to call)
- PESEL (ID number)
- Address (City, Postal Code)
- **Link:** "View Full Client Profile" button

#### Vehicle Information Card (Green)
**Vehicle Details:**
- Brand and Model
- Registration Number (in dark badge)
- Daily Rate
- Year, Body Type, Transmission
- Current Mileage

**Insurance Information:**
- Insurance company
- Policy number
- Valid dates
- **Link:** "View Full Vehicle Details" button

#### Employee Information Card (Gray)
- Employee name
- Position
- Phone number (clickable)
- **Link:** "View Employee Profile" button

#### Payment Summary Card (Right Side - Green)
**Financial Overview:**
- Total Cost
- Total Paid (in green)
- Balance (in red if unpaid)
- Warning alert if payment is due

#### Payment Transactions Card
**For Each Payment:**
- Payment ID
- Status badge (Completed, Pending, Failed, Refunded)
- Date
- Payment method
- Amount
- **Link:** View payment details button

**Actions:**
- "Add Payment" button (blue)

#### Quick Actions Card (Right Side - Yellow)
Context-sensitive buttons:
- **Return Vehicle** (if rental is Active)
- **Edit Rental** (if not completed/cancelled)
- **Cancel Rental** (if not completed/cancelled)
- **Add Payment** (always available)

---

## Editing a Rental

### When to Edit
- Change client information
- Modify rental dates
- Update assigned employee
- Change rental status
- Switch to a different vehicle (if available)

### Edit Process

1. **Open Edit Form:**
   - From details page: Click "Edit" button
   - From list page: Click edit icon in Actions column

2. **Editable Fields:**

   **Client (Section 1):**
   - Change to a different client
   - Dropdown with all clients

   **Vehicle (Section 2):**
   - Current vehicle is displayed in info box
   - Can change to any available vehicle
   - **Important:** Only available cars appear in dropdown

   **Employee (Section 3):**
   - Change assigned staff member
   - Choose from all employees

   **Dates (Section 4):**
   - Modify rental start date
   - Adjust return date
   - Validation: Return must be after rental

   **Status (Section 5):**
   - Change rental status
   - **Important:** Status change affects vehicle availability
   - Info message explains the impact

3. **Information Panels (Right Side):**
   - **Current Rental Info:** Shows original values
   - **Status Guide:** Explains each status
   - **Important Notes:** Warnings about changes

4. **Save Changes:**
   - Click "Save Changes" (yellow button)
   - System validates all fields
   - Updates vehicle status if needed
   - Redirects to details page

### ?? Editing Warnings
- **Status Changes:** Affect vehicle availability
- **Vehicle Changes:** Only available cars can be selected
- **Payments:** Existing payments remain linked
- **Date Changes:** Must maintain valid date range

---

## Returning a Vehicle

### When to Use
Use the Return function when a customer brings back the rented vehicle.

### Return Process

1. **Access Return Page:**
   - From details: Click "Return Vehicle" button (green)
   - **Note:** Only available for **Active** rentals

2. **Review Return Information:**

   **Client Information:**
   - Verify customer identity
   - Check contact details
   - Confirm PESEL matches

   **Vehicle Information:**
   - Verify correct vehicle
   - Note registration number
   - Check current mileage

   **Rental Period Cards:**
   - **Start Date:** Original rental date
   - **Return Date:** Today's date (automatically set)
   - **Duration:** Total days calculation

   **Financial Summary Card (Green Border):**
   - Daily Rate
   - Number of Days
   - **Total Cost** (large, blue)
   - **Total Paid** (large, green)
   - **Balance Due** (large, red or green)

3. **Payment Status Check:**

   **If Balance is Due (Red Alert):**
   - Amount remaining is displayed
   - "Payment Required!" warning
   - "Record Payment" button provided
   - **Action Required:** Collect payment before completing return

   **If Fully Paid (Green Alert):**
   - "Fully Paid!" confirmation
   - Can proceed with return

4. **Vehicle Inspection Checklist:**
   Use the checklist on the right side:
   - ? Exterior condition checked
   - ? Interior condition checked
   - ? Fuel level verified
   - ? Mileage recorded
   - ? Personal items removed
   - ? Keys returned
   - ? Documents verified

5. **Payment History:**
   - Shows all payments made
   - Dates, methods, amounts
   - Status of each payment

6. **Confirm Return:**
   - Review the confirmation checklist:
     - Vehicle inspected for damage
     - Fuel level verified
     - Personal items removed
     - Cleanliness acceptable
     - Balance will be collected (if due)
   - Click **"Confirm Vehicle Return"** (green button)

7. **What Happens:**
   - Rental status ? **Completed**
   - Return date set to today
   - Vehicle status ? **Available** (if no other rentals)
   - Success message displayed
   - Redirected to details page

### ?? Return Best Practices
- **Always** inspect vehicle before confirming
- **Record** any damage or issues
- **Collect** outstanding payments
- **Verify** fuel level
- **Check** for personal belongings
- **Document** final mileage

---

## Cancelling a Rental

### When to Cancel
- Customer requests cancellation
- Vehicle becomes unavailable
- Reservation needs to be voided
- Administrative reasons

### Cancellation Process

1. **Access Cancel Page:**
   - From details: Click "Cancel Rental" button (red)
   - **Note:** Cannot cancel completed or already cancelled rentals

2. **Review Cancellation Impact:**

   **Warning Alert (Red):**
   - "You are about to cancel this rental"
   - "This action cannot be undone automatically"
   - Recommends reviewing all details

   **Rental Summary:**
   - Client name and contact
   - Vehicle details
   - Current status
   - Rental period

3. **Financial Considerations:**

   **If Payments Exist (Yellow Warning):**
   - Shows total payments received
   - "Payment Alert" with amount
   - Refund process guidance:
     1. Calculate refund based on policy
     2. Go to Payments section
     3. Update payment status to "Refunded"
     4. Process refund through payment processor
     5. Notify client

   **Payment History Table:**
   - All payments made
   - Dates, methods, amounts, statuses

4. **What Happens When You Cancel:**
   Information box explains:
   - Status changes to **Cancelled**
   - Vehicle marked as **Available**
   - Client notified
   - Record preserved
   - Payments remain linked
   - May need to process refunds manually

5. **Cancellation Guidelines (Right Side):**

   **Before Cancelling:**
   - Contact client to confirm
   - Explain refund policy
   - Document cancellation reason
   - Check outstanding payments

   **After Cancellation:**
   - Send confirmation to client
   - Process refunds if needed
   - Update vehicle availability
   - Document in customer records

6. **Alternative Actions:**
   Consider these first:
   - Reschedule rental dates
   - Offer alternative vehicle
   - Contact supervisor

7. **Confirm Cancellation:**
   - Click **"Confirm Cancellation"** (red button)
   - JavaScript popup asks for final confirmation
   - Status updates to Cancelled
   - Vehicle released
   - Success message shown

### ?? Cancellation Notes
- **Refunds:** Must be processed manually in Payments
- **Record Kept:** Cancellation is logged, not deleted
- **Alternative:** Consider rescheduling instead
- **Policy:** Follow company cancellation policy

---

## Deleting a Rental

### ?? Critical Warning
**Deletion is PERMANENT and should be used VERY RARELY!**

### When to Delete (Only These Cases)
- Rental created by mistake
- Duplicate entry was made
- Test data needs removal
- Data correction required

### When NOT to Delete
- ? Rental was completed normally
- ? Has historical value
- ? Has associated payments
- ? Part of business records

### Delete Process

1. **Access Delete Page:**
   - From details: Click "Delete" button (outline red)

2. **Critical Warning (Red Alert):**
   - "PERMANENT DELETION WARNING"
   - "You are about to permanently delete this rental record"
   - "This action CANNOT BE UNDONE"
   - "Will result in loss of historical data"

3. **Payment Check:**

   **If Payments Exist (Red Alert):**
   - **"Cannot Delete!"** message
   - Shows number of associated payments
   - Delete button is **NOT shown**
   - **Action Required:** Delete all payments first
   - Link to view payments provided

   **If No Payments:**
   - Delete button is available
   - Proceed with caution

4. **What Will Be Deleted:**
   - Complete rental record
   - Rental transaction history
   - Client-vehicle association
   - Employee assignment record

5. **Guidelines Panel (Right Side):**

   **When to Delete (Red):**
   - Mistake/duplicate/test data
   - Data correction needed

   **DO NOT Delete:**
   - Normal completed rentals
   - Records with historical value
   - Rentals with payments
   - Business records

6. **Better Alternatives:**
   - Cancel the rental (keeps record)
   - Edit rental details (fix mistakes)
   - Leave as-is (maintain audit trail)

7. **Compliance Notice:**
   - Deleting may violate data retention policies
   - Financial records should be preserved
   - Audit trails are important
   - **Recommendation:** Use cancellation instead

8. **Confirm Deletion (If No Payments):**
   - Click **"Permanently Delete Rental"** (red button)
   - Triple-confirmation popup:
     - "?? FINAL WARNING ??"
     - "PERMANENTLY DELETE rental #X"
     - "This action CANNOT BE UNDONE!"
     - "Are you absolutely certain?"
   - Rental is deleted from database
   - Success message shown
   - Redirected to rentals list

### ?? Deletion Best Practices
- **Think Twice:** Consider alternatives first
- **Check Payments:** Ensure no payments exist
- **Consult Management:** Get approval
- **Document Reason:** Keep a record why
- **Use Rarely:** Last resort only

---

## Understanding Rental Statuses

### ?? Reserved
**What it means:**
- Customer has made a reservation
- Vehicle is being held for them
- Pickup is scheduled for future

**Vehicle Status:** Reserved

**Typical Actions:**
- Edit rental details
- Change to Active (when customer picks up)
- Cancel if customer doesn't show up

**Progression:**
- Reserved ? Active (on pickup)
- Reserved ? Cancelled (if no-show)

---

### ?? Active
**What it means:**
- Customer has picked up the vehicle
- Vehicle is currently with the customer
- Rental is in progress

**Vehicle Status:** Rented

**Typical Actions:**
- Return Vehicle (primary action)
- Edit rental (extend dates, etc.)
- Cancel (rare, emergency only)

**Progression:**
- Active ? Completed (normal return)
- Active ? Overdue (if past return date)
- Active ? Cancelled (emergency only)

---

### ?? Completed
**What it means:**
- Vehicle has been returned
- Rental successfully finished
- All processes complete

**Vehicle Status:** Available

**Typical Actions:**
- View details only
- No editing allowed
- Record is historical

**This is the final successful state.**

---

### ? Cancelled
**What it means:**
- Rental was cancelled
- Vehicle was released
- Record preserved for history

**Vehicle Status:** Available

**Typical Actions:**
- View details only
- No editing allowed
- Check refund status
- Review cancellation reason

**This is a final state (not successful).**

---

### ?? Overdue
**What it means:**
- Return date has passed
- Vehicle not yet returned
- Requires immediate attention

**Vehicle Status:** Rented (still out)

**Typical Actions:**
- Contact customer urgently
- Return Vehicle (when brought back)
- Assess late fees
- Check vehicle status

**Progression:**
- Overdue ? Completed (when returned)
- Overdue ? Contact customer

---

## Tips & Best Practices

### Creating Rentals
? **DO:**
- Verify client ID before creating
- Check vehicle condition
- Confirm insurance is active
- Document vehicle mileage
- Collect initial payment/deposit
- Set realistic return dates
- Choose correct initial status

? **DON'T:**
- Create without verifying client
- Skip vehicle inspection
- Forget to check insurance
- Use past dates
- Leave payment uncollected

### Managing Active Rentals
? **DO:**
- Monitor return dates
- Follow up on overdue rentals
- Keep payment records updated
- Document any issues
- Communicate with clients

? **DON'T:**
- Ignore overdue rentals
- Forget to collect payments
- Skip vehicle inspections
- Lose communication with client

### Returning Vehicles
? **DO:**
- Complete full inspection
- Verify mileage
- Check fuel level
- Collect outstanding balance
- Document any damage
- Get customer signature
- Update status promptly

? **DON'T:**
- Skip inspection
- Forget damage documentation
- Leave balance unpaid
- Rush the process

### Cancelling Rentals
? **DO:**
- Contact client first
- Explain refund policy
- Document reason
- Process refunds properly
- Update records
- Send confirmation

? **DON'T:**
- Cancel without client contact
- Forget refund processing
- Delete the record
- Skip documentation

---

## Common Scenarios

### Scenario 1: Customer Calls to Reserve
**Steps:**
1. Click "New Rental"
2. Search for customer in Client dropdown
3. If new: Click "Add New Client" first
4. Select available vehicle
5. Set rental dates (future)
6. Choose **"Reserved"** status
7. Create rental
8. Send confirmation to customer

### Scenario 2: Customer Picks Up Reserved Vehicle
**Steps:**
1. Find rental in list (Reserved status)
2. Click to view details
3. Click "Edit"
4. Change status to **"Active"**
5. Verify rental dates
6. Save changes
7. Inspect vehicle with customer
8. Collect payment/deposit
9. Hand over keys

### Scenario 3: Customer Returns Vehicle
**Steps:**
1. Find rental in list (Active status)
2. Click "Return Vehicle"
3. Complete inspection checklist
4. Verify mileage
5. Check for damage
6. Review financial summary
7. Collect outstanding balance (if any)
8. Click "Confirm Vehicle Return"
9. Give receipt to customer

### Scenario 4: Customer Cancels Reservation
**Steps:**
1. Find rental in list
2. Click to view details
3. Click "Cancel Rental"
4. Review financial impact
5. Calculate refund (if paid)
6. Confirm cancellation
7. Process refund in Payments
8. Send cancellation confirmation
9. Update customer notes

### Scenario 5: Customer Extends Rental
**Steps:**
1. Find rental (Active status)
2. Click "Edit"
3. Change return date to new date
4. System recalculates total cost
5. Save changes
6. Add additional payment if needed
7. Send confirmation

### Scenario 6: Rental Goes Overdue
**Steps:**
1. System marks as Overdue (or manual)
2. Contact customer immediately
3. Document contact attempts
4. When returned: Click "Return Vehicle"
5. Calculate late fees
6. Add late fee payment
7. Complete return process
8. Document reason for delay

---

## Troubleshooting

### Problem: "Car is not available"
**Cause:** Vehicle is already rented or in maintenance

**Solution:**
1. Check vehicle's current status
2. View vehicle details
3. Check overlapping rentals
4. Choose different vehicle OR
5. Schedule for later date

---

### Problem: "Cannot delete rental - has payments"
**Cause:** Rental has associated payment records

**Solution:**
1. View payment details
2. Delete/cancel each payment first
3. Then return to delete rental OR
4. Better: Cancel rental instead of deleting

---

### Problem: "Return date must be after rental date"
**Cause:** Invalid date range selected

**Solution:**
1. Verify rental start date
2. Set return date to at least 1 day after
3. System prevents same-day or earlier dates

---

### Problem: "Overlapping rental dates"
**Cause:** Vehicle already booked for those dates

**Solution:**
1. Check vehicle's rental history
2. Choose different dates OR
3. Choose different vehicle
4. System prevents double-booking

---

### Problem: "Payment not showing in total"
**Cause:** Payment status is not "Completed"

**Solution:**
1. View payment details
2. Check payment status
3. Update to "Completed" if received
4. Only completed payments count toward balance

---

### Problem: "Cannot return vehicle - balance due"
**Cause:** This is a warning, not an error

**Solution:**
1. Review outstanding balance
2. Click "Record Payment" link
3. Add final payment
4. Return to complete return
5. OR proceed with return and note balance

---

### Problem: "Cannot edit completed rental"
**Cause:** Completed rentals are locked

**Solution:**
- Completed rentals cannot be edited (by design)
- This preserves historical accuracy
- If correction needed: Contact supervisor
- For new changes: Create new rental

---

## Need Help?

### Support Resources
- **Manager:** Consult for complex cases
- **IT Support:** For system issues
- **Documentation:** Refer to technical docs
- **Training:** Request additional training

### Quick Tips
- Use filters to find rentals quickly
- Check payment status before returning
- Always document unusual situations
- Keep customer communication records
- Follow company policies and procedures

---

**Last Updated:** January 15, 2026  
**Version:** 1.0.0  
**Module Status:** Production Ready ?

---

**Thank you for using the Rentals Module! For additional assistance, please contact your system administrator.**
