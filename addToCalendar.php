<?php
// addToCalendar.php

// Load required libraries
require_once 'sessionManager.php';
require_once 'o365/Office365Service.php';

// Initialize session
session_start();

// Check if user is authenticated
if (!isset($_SESSION['access_token'])) {
    header('Location: home.php');
    exit();
}

// Create an instance of the Office365Service
$service = new Office365Service($_SESSION['access_token']);

// Define event details
$event = array(
    'subject' => 'My Event',
    'start' => array(
        'dateTime' => '2024-03-10T10:00:00',
        'timeZone' => 'UTC',
    ),
    'end' => array(
        'dateTime' => '2024-03-10T12:00:00',
        'timeZone' => 'UTC',
    ),
);

// Add the event to the user's calendar
$response = $service->addEvent($event);

// Handle response (you can customize this part)
if ($response['status'] === 'success') {
    echo 'Event added successfully!';
} else {
    echo 'Error adding event: ' . $response['message'];
}
?>
