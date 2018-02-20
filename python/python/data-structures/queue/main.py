import random
from queue import Queue
from simulation import task as CTask
from simulation import printer


def new_print_task():
    num = random.randrange(1, 181)
    return num == 180


def simulation(num_seconds, pages_per_minute):
    lab_printer = printer.Printer(pages_per_minute)
    print_queue = Queue()
    waiting_items = []

    for current_second in range(num_seconds):
        if new_print_task():
            task = CTask.Task(current_second)
            print_queue.enqueue(task)

        if (not lab_printer.busy()) and (not print_queue.is_empty()):
            next_task = print_queue.dequeue()
            waiting_items.append(next_task.wait_time(current_second))

        lab_printer.tick()

    average_wait = sum(waiting_items) / len(waiting_items)
    print("Average wait %6.2f secs %3d tasks remaining" % (average_wait, print_queue.size()))


for i in range(10):
    simulation(3600, 5)
